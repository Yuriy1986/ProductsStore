using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsStore.DAL.EF;
using ProductsStore.DAL.Entities;
using ProductsStore.DAL.Interfaces;
using ProductsStore.DAL.Models;

namespace ProductsStore.DAL.Repositories
{
    public class RepositoryShipments : IRepositoryShipments
    {
        readonly ApplicationDbContext db;

        public RepositoryShipments(ApplicationDbContext context)
        {
            this.db = context;
        }
        
        public DateTime MaxDateShipment(string login)
        {
           return db.Shipments.Where(x => x.Manager.UserName == login).Max(x => x.ShipmentDate);
        }

        public decimal AverageSum(string login, int year, int month)
        {
            return db.Shipments.Where(x => x.Manager.UserName == login && x.ShipmentDate.Year == year && x.ShipmentDate.Month == month)
                        .Average(x => x.Sum);
        }

        public ModelShipments CreateShipment(Shipment shipment, Manager userCurrent)
        {
            db.Shipments.Add(shipment);
            shipment.Manager = userCurrent;
            db.Entry(shipment).State = EntityState.Added;
            db.SaveChanges();

            ModelShipments modelShipments = new ModelShipments
            {
                Id = shipment.Id,
                SurnameName = shipment.Manager.Surname + " " + shipment.Manager.Name
            };
            return modelShipments;
        }

        public async Task SaveShipment()
        {
            await db.SaveChangesAsync();
        }

        public void DeleteShipment(Shipment shipmentCurrent)
        {
            db.Shipments.Remove(shipmentCurrent);
            db.Entry(shipmentCurrent).State = EntityState.Deleted;
        }

        public Shipment GetShipment(string login)
        {
            return db.Shipments.FirstOrDefault(x => x.Manager.UserName == login);
        }

        public Shipment GetShipment(string login, int year, int month)
        {
            return db.Shipments.FirstOrDefault(x => x.Manager.UserName == login && x.ShipmentDate.Year == year && x.ShipmentDate.Month == month);
        }

        public Shipment GetShipment(int idShipment)
        {
            return db.Shipments.FirstOrDefault(x => x.Id == idShipment);
        }

        public IEnumerable<ModelShipments> GetShipments(string query)
        {
            List<ModelShipments> modelShipments;
            modelShipments = db.Database.SqlQuery<ModelShipments>(query).ToList();
            return modelShipments;
        }
    }
}
