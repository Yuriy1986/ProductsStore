using System;
using System.Collections.Generic;
using ProductsStore.BLL.DTO;

namespace ProductsStore.BLL.Interfaces
{
    public interface IShipmentService : IDisposable
    {
        string CreateShipment(DTOShipmentsViewModel dtoShipmentsViewModel);

        IEnumerable<DTOShipmentsViewModel> GetShipments();
    }
}
