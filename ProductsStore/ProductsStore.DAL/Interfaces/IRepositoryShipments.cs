using ProductsStore.DAL.Entities;
using ProductsStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProductsStore.DAL.Interfaces
{
    public interface IRepositoryShipments
    {
        DateTime MaxDateShipment(string login);

        decimal AverageSum(string login, int year, int month);

        ModelShipments CreateShipment(Shipment shipment, Manager userCurrent);

        Task SaveShipment();

        void DeleteShipment(Shipment shipmentCurrent);

        Shipment GetShipment(string login);

        Shipment GetShipment(string login, int year, int month);

        Shipment GetShipment(int idShipment);
        
        IEnumerable<ModelShipments> GetShipments(string query);
    }
}
