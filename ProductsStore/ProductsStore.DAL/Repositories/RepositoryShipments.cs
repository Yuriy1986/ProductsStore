using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

        public bool DeleteShipment(int idShipment)
        {
            var shipmentCurrent = db.Shipments.FirstOrDefault(x => x.Id == idShipment);
            if (shipmentCurrent != null)
            {
                db.Shipments.Remove(shipmentCurrent);
                db.Entry(shipmentCurrent).State = EntityState.Deleted;
                db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void SaveShipment(Shipment shipment, Manager userCurrent)
        {
            db.Shipments.Add(shipment);
            shipment.Manager = userCurrent;
            db.Entry(shipment).State = EntityState.Added;
            db.SaveChangesAsync();
        }

        public IEnumerable<ModelShipments> GetShipments(bool Date = false, bool Company = false, bool City = false, bool Country = false, bool SurnameName = false)
        {
            List<ModelShipments> modelShipments;

            if (!Date && !Company && !City && !Country && !SurnameName)
            {
                string query = "SELECT S.Id, S.ShipmentDate,S.Company,S.City,S.Country, A.Surname+' '+A.Name as SurnameName, A.UserName as Login, S.Quantity,S.Sum FROM Shipments S INNER JOIN AspNetUsers A ON S.Manager_Id = A.Id";
                modelShipments = db.Database.SqlQuery<ModelShipments>(query).ToList();
                return modelShipments;
            }
            else
            {
                StringBuilder queryBegin = new StringBuilder("SELECT ");
                StringBuilder queryEnd = new StringBuilder(" FROM Shipments S INNER JOIN AspNetUsers A ON S.Manager_Id=A.Id GROUP BY ");
                if (Date)
                {
                    queryBegin.Append("CAST(S.ShipmentDate AS date) as ShipmentDate, ");
                    queryEnd.Append("CAST(S.ShipmentDate AS date),");
                }
                if (Company)
                {
                    queryBegin.Append("S.Company, ");
                    queryEnd.Append("S.Company,");
                }
                if (City)
                {
                    queryBegin.Append("S.City, ");
                    queryEnd.Append("S.City,");
                }
                if (Country)
                {
                    queryBegin.Append("S.Country, ");
                    queryEnd.Append("S.Country,");
                }
                if (SurnameName)
                {
                    queryBegin.Append("A.Surname+' '+A.Name as SurnameName, ");
                    queryEnd.Append("A.Surname+' '+A.Name,");
                }
                string query = queryBegin.Append("Sum(S.Quantity) as Quantity,Sum(S.Sum) as Sum").ToString() + queryEnd.Remove(queryEnd.Length-1,1).ToString();
                modelShipments = db.Database.SqlQuery<ModelShipments>(query).ToList();
                return modelShipments;
            }
        }
    }
}
