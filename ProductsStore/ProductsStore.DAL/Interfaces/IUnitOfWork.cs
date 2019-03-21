using System;
using System.Threading.Tasks;
using ProductsStore.DAL.Identity;
using ProductsStore.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ProductsStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryShipments Shipments { get; }

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IEnumerable<string> GetAllLogins();

        Manager GetManager(string login);

        Manager GetManager(string name, string surname, string patronymic);

        Task SaveUserAsync(Manager userCurrent, EntityState state);

        void SaveUser(Manager userCurrent, EntityState state);

        void DeleteUser(Manager userCurrent);
    }
}
