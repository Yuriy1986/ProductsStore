using ProductsStore.BLL.DTO;
using ProductsStore.DAL.Entities;
using ProductsStore.BLL.Interfaces;
using ProductsStore.DAL.Interfaces;
using System.Collections.Generic;
//using AutoMapper;

namespace ProductsStore.BLL.Services
{
    public class ShipmentService : IShipmentService
    {
        IUnitOfWork Database { get; set; }

        public ShipmentService(IUnitOfWork uow)
        {
            Database = uow;
        }
        

        public void Dispose()
        {
            Database.Dispose();
        }

        public bool CreateShipment()
        {
            return Database.Shipments.CreateShipment();
        }


    }
}
