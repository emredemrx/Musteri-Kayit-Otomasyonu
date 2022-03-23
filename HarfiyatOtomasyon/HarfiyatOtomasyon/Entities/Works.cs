using System.ComponentModel.DataAnnotations;

namespace HarfiyatOtomasyon.Entities
{
    public class Works
    {
        [Key]
        public int WorksId { get; set; }
        public int CustomerID { get; set; }
        public decimal CustomerDept { get; set; }
        public decimal RemainingDept { get; set; }
        public string LastPayment { get; set; }
        public int WorksStatus { get; set; }
    }
}
