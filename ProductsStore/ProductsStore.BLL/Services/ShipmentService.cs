﻿using ProductsStore.BLL.DTO;
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

        public string CreateShipment(DTOShipmentsViewModel dtoShipmentsViewModel)
        {
            Shipment shipment = new Shipment
            {
                ShipmentDate=dtoShipmentsViewModel.ShipmentDate,
                Company=dtoShipmentsViewModel.Company,
                City=dtoShipmentsViewModel.City,
                Country=dtoShipmentsViewModel.Country,                
                Quantity=dtoShipmentsViewModel.Quantity,
                Sum=dtoShipmentsViewModel.Sum
            };

            return Database.Shipments.CreateShipment(shipment, dtoShipmentsViewModel.Login);
        }

        public IEnumerable<DTOShipmentsViewModel> GetShipments()
        {
            var shipments = Database.Shipments.GetShipments();

            List<DTOShipmentsViewModel> dtoShipmentsViewModel = new List<DTOShipmentsViewModel>();

            foreach (var item in shipments)
            {
                dtoShipmentsViewModel.Add(new DTOShipmentsViewModel() {
                    Id=item.Id,
                    ShipmentDate=item.ShipmentDate,
                    Company=item.Company,
                    City=item.City,
                    Country=item.Country,
                    SurnameName=item.Manager.Surname+" "+item.Manager.Name,
                    Login=item.Manager.UserName,
                    Quantity=item.Quantity,
                    Sum=item.Sum
                });
            }

            return dtoShipmentsViewModel;
        }
    }
}
