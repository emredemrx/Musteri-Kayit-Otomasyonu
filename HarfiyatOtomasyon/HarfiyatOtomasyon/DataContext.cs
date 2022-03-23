using System.Data.Entity;
using HarfiyatOtomasyon.Entities;

namespace HarfiyatOtomasyon
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Musteri { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Works> Works { get; set; }
    }
}
