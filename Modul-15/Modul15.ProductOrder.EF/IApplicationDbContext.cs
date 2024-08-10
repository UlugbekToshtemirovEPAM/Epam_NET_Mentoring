using Microsoft.EntityFrameworkCore;
using Modul15.ProductOrder.EF.Domain;

namespace Modul15.ProductOrder.EF
{
    public interface IApplicationDbContext
    {
       public DbSet<Order> Orders { get; set; }
       public DbSet<Product> Products { get; set; }
       public Task<int> SaveChangesAsync();
    }
}
