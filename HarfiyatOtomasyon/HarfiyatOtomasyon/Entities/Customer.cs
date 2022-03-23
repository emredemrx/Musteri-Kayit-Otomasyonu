using System;
using System.ComponentModel.DataAnnotations;

namespace HarfiyatOtomasyon.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Number { get; set; }
        public string CustomerAddress { get; set; }
        public int DrivingTime { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Payments { get; set; }
        public string Explanation { get; set; }
        public int Status { get; set; }
    }
}
