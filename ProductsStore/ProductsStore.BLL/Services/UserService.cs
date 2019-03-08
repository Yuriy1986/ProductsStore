using ProductsStore.BLL.DTO;
using ProductsStore.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using ProductsStore.BLL.Interfaces;
using ProductsStore.BLL.Infrastructure;
using ProductsStore.DAL.Interfaces;
using System;
using System.Linq;
using System.Security.Principal;
//using Microsoft.Owin.Security.DataProtection;
//using Microsoft.AspNet.Identity.Owin;
using ProductsStore.DAL.Repositories;
using System.Collections.Generic;
using System.Text;

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
            Database.CreateAdmin();
        }


        public IEnumerable<string> GetAllLogins()
        {
            return Database.GetAllLogins();
        }

        public string Login(DTOLoginViewModel dtoLoginViewModel)
        {
            return Database.Login(dtoLoginViewModel.Login, dtoLoginViewModel.Password);
        }

        public string ChangePassword(DTOChangePasswordViewModel dtoChangePasswordViewModel)
        {
            var password = new UserPasswordValidator();
            var validatePassword = password.ValidateAsync(dtoChangePasswordViewModel.NewPassword).Result;
            if (validatePassword.Errors.Count() > 0)
                return validatePassword.Errors.First();

            return Database.ChangePassword(dtoChangePasswordViewModel.Login, dtoChangePasswordViewModel.OldPassword, dtoChangePasswordViewModel.NewPassword);
        }

        public string Register(DTORegisterViewModel dtoRegisterViewModel)
        {
            Manager manager = new Manager
            {
                Name = dtoRegisterViewModel.Name,
                Surname = dtoRegisterViewModel.Surname,
                Patronymic = dtoRegisterViewModel.Patronymic,
                UserName = dtoRegisterViewModel.Login
            };
            return Database.Register(manager, dtoRegisterViewModel.Password, dtoRegisterViewModel.Role);
        }

        public string ResetPassword(DTOChangePasswordAdminViewModel dtoChangePasswordAdminViewModel)
        {
            return Database.ResetPassword(dtoChangePasswordAdminViewModel.Login, dtoChangePasswordAdminViewModel.Password);
        }

        public DTOEditViewModel GetInformation(string login)
        {
            var manager = Database.GetInformation(login, out string role);
            if (manager == null)
                return null;

            DTOEditViewModel dtoEditViewModel = new DTOEditViewModel
            {
                Name = manager.Name,
                Surname = manager.Surname,
                Patronymic = manager.Patronymic,
                Login = manager.UserName,
                Role = role
            };
            return dtoEditViewModel;
        }

        public string EditUser(DTOEditViewModel dtoEditViewModel)
        {
            Manager manager = new Manager
            {
                Name = dtoEditViewModel.Name,
                Surname = dtoEditViewModel.Surname,
                Patronymic = dtoEditViewModel.Patronymic,
                UserName = dtoEditViewModel.Login
            };
            return Database.EditUser(manager, dtoEditViewModel.NewLogin, dtoEditViewModel.Role);
        }

        public string DeleteUser(string login)
        {
            return Database.DeleteUser(login);
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
