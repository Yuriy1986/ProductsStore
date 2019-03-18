using ProductsStore.BLL.DTO;
using ProductsStore.DAL.Entities;
using ProductsStore.BLL.Interfaces;
using ProductsStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;
using ProductsStore.DAL.Models;

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

        public string CreateShipment(DTOShipmentsViewModel dtoShipmentsViewModel)
        {
            Shipment shipment = new Shipment
            {
                ShipmentDate = dtoShipmentsViewModel.ShipmentDate,
                Company = dtoShipmentsViewModel.Company,
                City = dtoShipmentsViewModel.City,
                Country = dtoShipmentsViewModel.Country,
                Quantity = dtoShipmentsViewModel.Quantity,
                Sum = dtoShipmentsViewModel.Sum
            };

            return Database.Shipments.CreateShipment(shipment, dtoShipmentsViewModel.Login);
        }

        public bool DeleteShipment(int idShipment)
        {
            return Database.Shipments.DeleteShipment(idShipment);
        }

        public IEnumerable<DTOShipmentsViewModel> GetShipments(DTOGroupingShipsmentsViewModel dtoGroupingShipsmentsViewModel=null)
        {
            IEnumerable<ModelShipments> shipments;
            if (dtoGroupingShipsmentsViewModel == null)
                shipments = Database.Shipments.GetShipments();
            else
                shipments = Database.Shipments.GetShipments(dtoGroupingShipsmentsViewModel.Date, dtoGroupingShipsmentsViewModel.Company, dtoGroupingShipsmentsViewModel.City,
             dtoGroupingShipsmentsViewModel.Country, dtoGroupingShipsmentsViewModel.Surname);

            List<DTOShipmentsViewModel> dtoShipmentsViewModel = new List<DTOShipmentsViewModel>();

            foreach (var item in shipments)
            {
                dtoShipmentsViewModel.Add(new DTOShipmentsViewModel()
                {
                    Id = item.Id,
                    ShipmentDate = item.ShipmentDate,
                    Company = item.Company,
                    City = item.City,
                    Country = item.Country,
                    SurnameName = item.SurnameName,
                    Login = item.Login,
                    Quantity = item.Quantity,
                    Sum = item.Sum
                });
            }
            return dtoShipmentsViewModel;
        }
    }
}
