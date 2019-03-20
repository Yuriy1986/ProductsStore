using System;

namespace ProductsStore.BLL.DTO
{
    public class DTOShipmentsViewModel
    {
        public int Id { get; set; }

        public DateTime ShipmentDate { get; set; }

        public string Company { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string SurnameName { get; set; }

        public string Login { get; set; }

        public int Quantity { get; set; }

        public decimal Sum { get; set; }
    }
}
