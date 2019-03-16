using ProductsStore.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ProductsStore.DAL.Interfaces
{
    public interface IRepositoryShipments
    {
        string CreateShipment(Shipment shipment, string login);

        bool DeleteShipment(int idShipment);
        
        IEnumerable<Shipment> GetShipments(bool Date=false, bool Company = false, bool City = false, bool Country = false, bool Surname = false);
    }
}
