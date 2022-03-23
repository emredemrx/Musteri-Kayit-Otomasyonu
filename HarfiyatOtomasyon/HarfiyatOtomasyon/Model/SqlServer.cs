using System;
using System.Linq;
using HarfiyatOtomasyon.Entities;

namespace HarfiyatOtomasyon.Model
{
    class SqlServer : IDataOperations
    {
        public void Add(int vehicleid, string customerFirstName, string customerLastName, string number, string customerAddress, int drivingTime, DateTime dateOfStart, DateTime endDate, decimal payments, string explanation, int status)

        {
            using (DataContext context = new DataContext())
            {
                Customer customer = new Customer();
                customer.VehicleID = vehicleid;
                customer.CustomerFirstName = customerFirstName;
                customer.CustomerLastName = customerLastName;
                customer.Number = number;
                customer.CustomerAddress = customerAddress;
                customer.DrivingTime = drivingTime;
                customer.DateOfStart = dateOfStart;
                customer.EndDate = endDate;
                customer.Payments = payments;
                customer.Explanation = explanation;
                customer.Status = status;
                context.Musteri.Add(customer);
                context.SaveChanges();
            }
        }
        public void Delete(int a)
        {
            using (DataContext context = new DataContext())
            {
                var deleteData = context.Musteri.Where(w => w.CustomerID == a).FirstOrDefault();
                context.Musteri.Remove(deleteData);
                context.SaveChanges();
            }
        }
        public void Update(int update, int vehicleid, string customerFirstName, string customerLastName, string number, string customerAddress, int drivingTime, DateTime dateOfStart, DateTime endDate, decimal payments, string explanation, int status)
        {
            using (DataContext context = new DataContext())
            {
                var upd = context.Musteri.Where(w => w.CustomerID == update).FirstOrDefault();
                upd.VehicleID = vehicleid;
                upd.CustomerFirstName = customerFirstName;
                upd.CustomerLastName = customerLastName;
                upd.Number = number;
                upd.CustomerAddress = customerAddress;
                upd.DrivingTime = drivingTime;
                upd.DateOfStart = dateOfStart;
                upd.EndDate = endDate;
                upd.Payments = payments;
                upd.Explanation = explanation;
                upd.Status = status;
                context.SaveChanges();
            }
        }
    }
}
