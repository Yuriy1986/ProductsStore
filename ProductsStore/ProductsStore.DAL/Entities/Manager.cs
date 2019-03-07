using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductsStore.DAL.Entities
{
    public class Manager : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public ICollection<Shipment> Shipments { get; set; }

        public Manager()
        {
            Shipments = new List<Shipment>();
        }
    }
}
