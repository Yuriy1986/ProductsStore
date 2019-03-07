using System;
using System.Threading.Tasks;
using ProductsStore.DAL.Identity;
using ProductsStore.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductsStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
    //    IRepositoryShipments Shipments { get; }

        void CreateAdmin();

        IEnumerable<string> GetAllLogins();

        string Login(string login, string password);

        string ChangePassword(string login, string oldPassword, string newPassword);

        string Register(Manager manager, string password, string role);

        string ResetPassword(string login, string password);

        Manager GetInformation(string login, out string role);

        string EditUser(Manager manager, string newLogin, string role);

        string DeleteUser(string login);

    }
}
