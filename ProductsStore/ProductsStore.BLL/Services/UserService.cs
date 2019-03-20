using ProductsStore.BLL.DTO;
using ProductsStore.DAL.Entities;
using Microsoft.AspNet.Identity;
using ProductsStore.BLL.Interfaces;
using ProductsStore.BLL.Infrastructure;
using ProductsStore.DAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProductsStore.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateAdmin()
        {
            Manager admin = new Manager
            {
                Name = "Ivan",
                Surname = "Ivanov",
                Patronymic = "Ivanovich",
                UserName = "administrator",
                LockoutEnabled = false
            };
            string password = "Qwerty_123456789";
            Database.UserManager.Create(admin, password);
            Database.UserManager.AddToRoleAsync(admin.Id, "admin");
        }

        public IEnumerable<string> GetAllLogins()
        {
            return Database.GetAllLogins();
        }

        public string Login(DTOLoginViewModel dtoLoginViewModel)
        {
            var userCurrent = Database.GetManager(dtoLoginViewModel.Login);

            if (userCurrent.LockoutEnabled && userCurrent.LockoutEndDateUtc != null)
                return "User is locked. For unlock contact your administrator.";
            if (Database.UserManager.CheckPassword(userCurrent, dtoLoginViewModel.Password))
            {
                if (!userCurrent.LockoutEnabled || userCurrent.AccessFailedCount > 0)
                {
                    if (userCurrent.AccessFailedCount != 3)
                    {
                        userCurrent.AccessFailedCount = 3;
                        Database.SaveUser(userCurrent, EntityState.Modified);
                    }
                    return Database.UserManager.GetRoles(userCurrent.Id).First();
                }
            }
            else
            {
                if (userCurrent.LockoutEnabled)
                {
                    userCurrent.AccessFailedCount--;
                    if (userCurrent.AccessFailedCount == 0)
                        userCurrent.LockoutEndDateUtc = DateTime.Parse("01-01-2999");
                    Database.SaveUser(userCurrent, EntityState.Modified);
                    return "Login or password incorrect. Input attempts: " + userCurrent.AccessFailedCount;
                }
                return "Login or password incorrect.";
            }
            return "Close this window and reset program.";
        }

        public string ChangePassword(DTOChangePasswordViewModel dtoChangePasswordViewModel)
        {
            var password = new UserPasswordValidator();
            var validatePassword = password.ValidateAsync(dtoChangePasswordViewModel.NewPassword).Result;
            if (validatePassword.Errors.Count() > 0)
                return validatePassword.Errors.First();

            var userCurrent = Database.GetManager(dtoChangePasswordViewModel.Login);
            if (userCurrent == null)
                return "Close this window and reset program.";

            var result = Database.UserManager.ChangePassword(userCurrent.Id, dtoChangePasswordViewModel.OldPassword, dtoChangePasswordViewModel.NewPassword);

            if (result.Succeeded)
                return null;
            return result.Errors.First();
        }

        public string Register(DTORegisterViewModel dtoRegisterViewModel)
        {
            var userCurrent = Database.GetManager(dtoRegisterViewModel.Login);

            if (userCurrent == null)
            {
                Manager manager = new Manager
                {
                    Name = dtoRegisterViewModel.Name,
                    Surname = dtoRegisterViewModel.Surname,
                    Patronymic = dtoRegisterViewModel.Patronymic,
                    UserName = dtoRegisterViewModel.Login
                };

                var user = Database.GetManager(dtoRegisterViewModel.Name, dtoRegisterViewModel.Surname, dtoRegisterViewModel.Patronymic); 
                if (user != null)
                    return "User with the same Name, Surname, Patronymic already exists.";

                if (dtoRegisterViewModel.Role == "admin")
                    manager.LockoutEnabled = false;
                else
                    manager.LockoutEnabled = true;

                manager.AccessFailedCount = 3;
                var result = Database.UserManager.Create(manager, dtoRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    Database.UserManager.AddToRoleAsync(manager.Id, dtoRegisterViewModel.Role);
                    return null;
                }
                return "Close this window and reset program.";
            }
            return "User with the same Login already exists.";
        }

        public string ResetPassword(DTOChangePasswordAdminViewModel dtoChangePasswordAdminViewModel)
        {
            var userCurrent = Database.GetManager(dtoChangePasswordAdminViewModel.Login);
            if (userCurrent != null)
            {
                var result = Database.UserManager.RemovePassword(userCurrent.Id);
                if (result.Succeeded)
                {
                    Database.UserManager.AddPassword(userCurrent.Id, dtoChangePasswordAdminViewModel.Password);
                    userCurrent.AccessFailedCount = 3;
                    userCurrent.LockoutEndDateUtc = null;
                    Database.SaveUser(userCurrent, EntityState.Modified);
                    return null;
                }
            }
            return "Close this window and reset program.";
        }

        public DTOEditViewModel GetInformation(string login)
        {
            var userCurrent = Database.GetManager(login);
            if (userCurrent != null)
            {
                string role = Database.UserManager.GetRoles(userCurrent.Id).First();
                DTOEditViewModel dtoEditViewModel = new DTOEditViewModel
                {
                    Name = userCurrent.Name,
                    Surname = userCurrent.Surname,
                    Patronymic = userCurrent.Patronymic,
                    Login = userCurrent.UserName,
                    Role = role
                };
                return dtoEditViewModel;
            }
            return null;
        }

        public string EditUser(DTOEditViewModel dtoEditViewModel)
        {
            var userCurrent = Database.GetManager(dtoEditViewModel.Login);
            if (userCurrent != null)
            {
                Manager user;
                if (dtoEditViewModel.NewLogin != null)
                {
                    user = Database.GetManager(dtoEditViewModel.NewLogin);
                    if (user != null)
                        return "User with the same Login already exists.";
                }

                user = Database.GetManager(dtoEditViewModel.Name, dtoEditViewModel.Surname, dtoEditViewModel.Patronymic);

                if (user != null && user.UserName != userCurrent.UserName)
                    return "User with the same Name, Surname, Patronymic already exists.";

                userCurrent.Name = dtoEditViewModel.Name;
                userCurrent.Surname = dtoEditViewModel.Surname;
                userCurrent.Patronymic = dtoEditViewModel.Patronymic;
                if (dtoEditViewModel.NewLogin != null)
                    userCurrent.UserName = dtoEditViewModel.NewLogin;
                var roleOld = Database.UserManager.GetRoles(userCurrent.Id).First();
                if (roleOld != dtoEditViewModel.Role)
                {
                    if (dtoEditViewModel.Role == "admin")
                        userCurrent.LockoutEnabled = false;
                    else    //user
                        userCurrent.LockoutEnabled = true;
                    Database.UserManager.RemoveFromRole(userCurrent.Id, roleOld);
                    Database.UserManager.AddToRole(userCurrent.Id, dtoEditViewModel.Role);
                }
                Database.SaveUser(userCurrent, EntityState.Modified);
                return null;
            }
            return "Close this window and reset program.";
        }

        public string DeleteUser(string login)
        {
            var userCurrent = Database.GetManager(login);
            if (userCurrent != null)
            {
                // If mamager maked shipments.
                if (Database.Shipments.GetShipment(login) != null)
                {
                    userCurrent.Deleted = true;
                    Database.SaveUser(userCurrent, EntityState.Modified);
                    return "Manager got value deleted in database (manager maked shipments) .";
                }
                // If mamager didn`t make shipments.
                else
                {
                    Database.DeleteUser(userCurrent);
                    Database.SaveUser(userCurrent, EntityState.Modified);
                    return "Manager deleted in database (manager didn`t make shipments).";
                }
            }
            return null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
