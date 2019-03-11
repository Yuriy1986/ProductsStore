using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProductsStore.DAL.EF;
using ProductsStore.DAL.Entities;
using ProductsStore.DAL.Interfaces;

namespace ProductsStore.DAL.Repositories
{
    public class RepositoryShipments : IRepositoryShipments
    {
        readonly ApplicationDbContext db;

        public RepositoryShipments(ApplicationDbContext context)
        {
            this.db = context;
        }

        public string CreateShipment(Shipment shipment, string login)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.UserName == login);
            if (userCurrent != null)
            {
                // If first manager`s shipment.
                if (db.Shipments.FirstOrDefault(x => x.Manager.UserName == login) == null)
                {
                    SaveShipment(shipment, userCurrent);
                    return null;
                }

                // If first manager`s shipment on current month and year.
                if (db.Shipments.FirstOrDefault(x => x.Manager.UserName == login && x.ShipmentDate.Year == shipment.ShipmentDate.Year && x.ShipmentDate.Month == shipment.ShipmentDate.Month) == null)
                {
                    var maxDateShipment = db.Shipments.Where(x => x.Manager.UserName == login).Max(x => x.ShipmentDate);

                    var averageSumLastMonth = db.Shipments.Where(x => x.Manager.UserName == login && x.ShipmentDate.Year == maxDateShipment.Year && x.ShipmentDate.Month == maxDateShipment.Month)
                        .Average(x => x.Sum);

                    if (shipment.Sum > averageSumLastMonth + 500)
                        return "Sum must be no more " + (averageSumLastMonth + 500) + " (average Sum of last month where were shipments for the current manager)+500";
                    SaveShipment(shipment, userCurrent);
                    return null;
                }

                // Sum< average sum on current month for current manager +500
                var averageSumCurrentMonth = db.Shipments.Where(x => x.Manager.UserName == login && x.ShipmentDate.Year == shipment.ShipmentDate.Year && x.ShipmentDate.Month == shipment.ShipmentDate.Month)
                       .Average(x => x.Sum);
                if (shipment.Sum > averageSumCurrentMonth + 500)
                    return "Sum must be no more " + (averageSumCurrentMonth + 500) + " (average Sum of current month for the current manager)+500";
                SaveShipment(shipment, userCurrent);
                return null;
            }
            return "Close this window and reset program.";
        }

        public void SaveShipment(Shipment shipment, Manager userCurrent)
        {
            db.Shipments.Add(shipment);
            shipment.Manager = userCurrent;
            db.Entry(shipment).State = EntityState.Added;
            db.SaveChangesAsync();
        }

        public IEnumerable<Shipment> GetShipments()
        {
            return db.Shipments.Include(x => x.Manager);
        }

    }
}
