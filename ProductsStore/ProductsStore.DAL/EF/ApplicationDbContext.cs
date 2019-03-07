using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProductsStore.DAL.Entities;
using Microsoft.AspNet.Identity;
using ProductsStore.DAL.Interfaces;

namespace ProductsStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<Manager>
    {
        public DbSet<Shipment> Shipments { get; set; }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new UserDbInitializer());
        }

        public ApplicationDbContext(string conectionString) : base(conectionString) { }
    }

    public class UserDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            db.Roles.Add(role1);
            db.Roles.Add(role2);
        }
    }
}
