using ProductsStore.BLL.DTO;
using ProductsStore.DAL.Entities;
using ProductsStore.BLL.Interfaces;
using ProductsStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

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

        public DTOCreateShipmentViewModel CreateShipment(DTOShipmentsViewModel dtoShipmentsViewModel)
        {             
            var userCurrent = Database.GetManager(dtoShipmentsViewModel.Login);
            DTOCreateShipmentViewModel dtoCreateShipmentViewModel = new DTOCreateShipmentViewModel();

            if (userCurrent != null)
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

                // If first manager`s shipment.
                if (Database.Shipments.GetShipment(dtoShipmentsViewModel.Login) == null)
                    return CreateShipmentExtension(shipment, userCurrent, dtoCreateShipmentViewModel);

                // If first manager`s shipment on current month and year.
                if (Database.Shipments.GetShipment(dtoShipmentsViewModel.Login, dtoShipmentsViewModel.ShipmentDate.Year, dtoShipmentsViewModel.ShipmentDate.Month) == null)
                {
                    var maxDateShipment = Database.Shipments.MaxDateShipment(dtoShipmentsViewModel.Login);

                    var averageSumLastMonth = Database.Shipments.AverageSum(dtoShipmentsViewModel.Login, maxDateShipment.Year, maxDateShipment.Month);

                    if (dtoShipmentsViewModel.Sum > averageSumLastMonth + 500)
                    {
                        dtoCreateShipmentViewModel.Responce = "Sum must be no more " + (averageSumLastMonth + 500) + " (average Sum of last month where were shipments for the current manager)+500.";
                        return dtoCreateShipmentViewModel;
                    }
                    return CreateShipmentExtension(shipment, userCurrent, dtoCreateShipmentViewModel);
                }

                // Sum< average sum on current month for current manager +500
                var averageSumCurrentMonth = Database.Shipments.AverageSum(dtoShipmentsViewModel.Login, dtoShipmentsViewModel.ShipmentDate.Year, dtoShipmentsViewModel.ShipmentDate.Month);

                if (dtoShipmentsViewModel.Sum > averageSumCurrentMonth + 500)
                {
                    dtoCreateShipmentViewModel.Responce = "Sum must be no more " + (averageSumCurrentMonth + 500) + " (average Sum of current month for the current manager)+500";
                    return dtoCreateShipmentViewModel;
                }
                return CreateShipmentExtension(shipment, userCurrent, dtoCreateShipmentViewModel);
            }
            dtoCreateShipmentViewModel.Responce = "Close this window and reset program.";
            return dtoCreateShipmentViewModel;
        }

        private DTOCreateShipmentViewModel CreateShipmentExtension(Shipment shipment, Manager userCurrent, DTOCreateShipmentViewModel dtoCreateShipmentViewModel)
        {
            var shipmentCurrent = Database.Shipments.CreateShipment(shipment, userCurrent);
            dtoCreateShipmentViewModel.Id = shipmentCurrent.Id;
            dtoCreateShipmentViewModel.SurnameName = shipmentCurrent.SurnameName;
            return dtoCreateShipmentViewModel;
        }

        public bool DeleteShipment(int idShipment)
        {
            var shipmentCurrent = Database.Shipments.GetShipment(idShipment);
            if (shipmentCurrent != null)
            {
                Database.Shipments.DeleteShipment(shipmentCurrent);
                Database.Shipments.SaveShipment();
                return true;
            }
            return false;
        }

        public IEnumerable<DTOShipmentsViewModel> GetShipments(DTOGroupingShipsmentsViewModel dtoGroupingShipsmentsViewModel=null)
        {
            string query;
            if (dtoGroupingShipsmentsViewModel == null)
                query = "SELECT S.Id, S.ShipmentDate,S.Company,S.City,S.Country, A.Surname+' '+A.Name as SurnameName, A.UserName as Login, S.Quantity,S.Sum FROM Shipments S INNER JOIN AspNetUsers A ON S.Manager_Id = A.Id";
            else
            {
                StringBuilder queryBegin = new StringBuilder("SELECT ");
                StringBuilder queryEnd = new StringBuilder(" FROM Shipments S INNER JOIN AspNetUsers A ON S.Manager_Id=A.Id GROUP BY ");
                if (dtoGroupingShipsmentsViewModel.Date)
                {
                    queryBegin.Append("CAST(S.ShipmentDate AS date) as ShipmentDate, ");
                    queryEnd.Append("CAST(S.ShipmentDate AS date),");
                }
                if (dtoGroupingShipsmentsViewModel.Company)
                {
                    queryBegin.Append("S.Company, ");
                    queryEnd.Append("S.Company,");
                }
                if (dtoGroupingShipsmentsViewModel.City)
                {
                    queryBegin.Append("S.City, ");
                    queryEnd.Append("S.City,");
                }
                if (dtoGroupingShipsmentsViewModel.Country)
                {
                    queryBegin.Append("S.Country, ");
                    queryEnd.Append("S.Country,");
                }
                if (dtoGroupingShipsmentsViewModel.SurnameName)
                {
                    queryBegin.Append("A.Surname+' '+A.Name as SurnameName, ");
                    queryEnd.Append("A.Surname+' '+A.Name,");
                }
                query = queryBegin.Append("Sum(S.Quantity) as Quantity,Sum(S.Sum) as Sum").ToString() + queryEnd.Remove(queryEnd.Length - 1, 1).ToString();
            }
            var shipments = Database.Shipments.GetShipments(query);

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
