using System;
using System.Collections.Generic;
using ProductsStore.BLL.DTO;

namespace ProductsStore.BLL.Interfaces
{
    public interface IShipmentService : IDisposable
    {
        string CreateShipment(DTOShipmentsViewModel dtoShipmentsViewModel);

        bool DeleteShipment(int idShipment);
        
        IEnumerable<DTOShipmentsViewModel> GetShipments(DTOGroupingShipsmentsViewModel dtoGroupingShipsmentsViewModel=null);
    }
}
