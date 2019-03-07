using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.DAL.Entities
{
    public class Shipment
    {
        public int Id { get; set; }

        public DateTime ShipmentDate { get; set; }

        public string Company { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Manager Manager { get; set; }

        public int Quantity { get; set; }

        public decimal Sum { get; set; }
    }
}
