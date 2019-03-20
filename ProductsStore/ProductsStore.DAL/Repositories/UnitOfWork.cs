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

        public ApplicationUserManager UserManager { get; }

        public ApplicationRoleManager RoleManager { get; }

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

        public IEnumerable<string> GetAllLogins()
        {
            return db.Users.Where(x=>x.Deleted==false).Select(x => x.UserName).ToList();
        }

        public Manager GetManager(string login)
        {
            return db.Users.FirstOrDefault(x => x.UserName == login);
        }

        public Manager GetManager(string name, string surname, string patronymic)
        {
            return db.Users.FirstOrDefault(x => x.Name == name && x.Surname == surname && x.Patronymic == patronymic);
        }

        public async Task SaveUser(Manager userCurrent, EntityState state)
        {
            db.Entry(userCurrent).State = state;
            await db.SaveChangesAsync();
        }

        public void DeleteUser(Manager userCurrent)
        {
            db.Users.Remove(userCurrent);
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