using System;
using System.ComponentModel.DataAnnotations;

namespace HarfiyatOtomasyon.Entities
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
