using ProductsStore.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace ProductsStore.DAL.Identity
{
    public class ApplicationUserManager:UserManager<Manager>
    {
        public ApplicationUserManager(IUserStore<Manager> store)
        : base(store)
        {
        }
    }
}
