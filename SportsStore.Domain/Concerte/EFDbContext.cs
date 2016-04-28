using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concerte
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
