using System.ComponentModel.DataAnnotations;

namespace HarfiyatOtomasyon.Entities
{
    public class User
    {
        [Key]
        public int UyeID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int UserStatus { get; set; }
    }
}
