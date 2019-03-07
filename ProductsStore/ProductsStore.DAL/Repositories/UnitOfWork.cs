using ProductsStore.DAL.EF;
using ProductsStore.DAL.Entities;
using ProductsStore.DAL.Interfaces;
using ProductsStore.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace ProductsStore.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext db;

        ApplicationUserManager UserManager { get; }

        ApplicationRoleManager RoleManager { get; }

        RepositoryShipments repositoryShipments;

        public UnitOfWork()
        {
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                MultipleActiveResultSets = true,
                InitialCatalog = "ShipmentsStore",
                IntegratedSecurity = true
            };

            db = new ApplicationDbContext(connection.ConnectionString);
            UserManager = new ApplicationUserManager(new UserStore<Manager>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(db));
            // Disable password reliability checking (Password reliability checking in BLL).
            UserManager.PasswordValidator = new PasswordValidator()
            { };
        }

        public IRepositoryShipments Shipments
        {
            get
            {
                if (repositoryShipments == null)
                    repositoryShipments = new RepositoryShipments(db);
                return repositoryShipments;
            }
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
            UserManager.CreateAsync(admin, password).Wait();
            UserManager.AddToRoleAsync(admin.Id, "admin");
        }

        public IEnumerable<string> GetAllLogins()
        {
            return db.Users.Select(x => x.UserName).ToList();
        }

        public string Login(string login, string password)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);

            if (userCurrent.LockoutEnabled && userCurrent.LockoutEndDateUtc != null)
                return "User is locked. For unlock contact your administrator.";
            if (UserManager.CheckPassword(userCurrent, password))
            {
                if (!userCurrent.LockoutEnabled || userCurrent.AccessFailedCount > 0)
                {
                    if (userCurrent.AccessFailedCount != 3)
                    {
                        userCurrent.AccessFailedCount = 3;
                        db.Entry(userCurrent).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return UserManager.GetRoles(userCurrent.Id).First();
                }
            }
            else
            {
                if (userCurrent.LockoutEnabled)
                {
                    userCurrent.AccessFailedCount--;
                    if (userCurrent.AccessFailedCount == 0)
                        userCurrent.LockoutEndDateUtc = DateTime.Parse("01-01-2999");
                    db.Entry(userCurrent).State = EntityState.Modified;
                    db.SaveChangesAsync();
                    return "Login or password incorrect. Input attempts: " + userCurrent.AccessFailedCount;
                }
                return "Login or password incorrect.";
            }
            return "Close this window and reset program.";
        }

        public string ChangePassword(string login, string oldPassword, string newPassword)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);
            if (userCurrent == null)
                return "Close this window and reset program.";

            var result = UserManager.ChangePassword(userCurrent.Id, oldPassword, newPassword);

            if (result.Succeeded)
                return null;
            return result.Errors.First();
        }

        public string Register(Manager manager, string password, string role)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == manager.UserName);

            if (userCurrent == null)
            {
                var user = db.Users.FirstOrDefault(x => x.Name == manager.Name && x.Surname == manager.Surname && x.Patronymic == manager.Patronymic);
                if (user != null)
                    return "User with the same Name, Surname, Patronymic already exists.";

                if (role == "admin")
                    manager.LockoutEnabled = false;
                else
                    manager.LockoutEnabled = true;

                manager.AccessFailedCount = 3;
                var result = UserManager.Create(manager, password);
                if (result.Succeeded)
                {
                    UserManager.AddToRoleAsync(manager.Id, role);
                    return null;
                }
                return "Close this window and reset program.";
            }
            return "User with the same Login already exists.";
        }

        public string ResetPassword(string login, string password)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);
            if (userCurrent != null)
            {
                var result = UserManager.RemovePassword(userCurrent.Id);
                if (result.Succeeded)
                {
                    UserManager.AddPassword(userCurrent.Id, password);
                    userCurrent.AccessFailedCount = 3;
                    userCurrent.LockoutEndDateUtc = null;
                    db.Entry(userCurrent).State = EntityState.Modified;
                    db.SaveChangesAsync();
                    return null;
                }
            }
            return "Close this window and reset program.";
        }

        public Manager GetInformation(string login, out string role)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);
            if (userCurrent != null)
            {
                role = UserManager.GetRoles(userCurrent.Id).First();
                return userCurrent;
            }
            role = "";
            return null;
        }

        public string EditUser(Manager manager, string newLogin, string role)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == manager.UserName);
            if (userCurrent != null)
            {
                Manager user;
                if (newLogin != null)
                {
                    user = db.Users.FirstOrDefault(x => x.UserName == newLogin);
                    if (user != null)
                        return "User with the same Login already exists.";
                }

                user = db.Users.FirstOrDefault(x => x.Name == manager.Name && x.Surname == manager.Surname && x.Patronymic == manager.Patronymic);

                if (user != null && user.UserName != userCurrent.UserName)
                    return "User with the same Name, Surname, Patronymic already exists.";

                userCurrent.Name = manager.Name;
                userCurrent.Surname = manager.Surname;
                userCurrent.Patronymic = manager.Patronymic;
                if (newLogin != null)
                    userCurrent.UserName = newLogin;
                var roleOld = UserManager.GetRoles(userCurrent.Id).First();
                if(roleOld!=role)
                {
                    if (role == "admin")
                        userCurrent.LockoutEnabled = false;
                    else    //user
                        userCurrent.LockoutEnabled = true;
                    UserManager.RemoveFromRole(userCurrent.Id, roleOld);
                    UserManager.AddToRole(userCurrent.Id, role);
                }

                db.Entry(userCurrent).State = EntityState.Modified;
                db.SaveChangesAsync();
                return null;
            }
            return "Close this window and reset program.";
        }

        public string DeleteUser(string login)/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);
            if(userCurrent!=null)
            {
                var fff = userCurrent.Shipments;
            }
            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
