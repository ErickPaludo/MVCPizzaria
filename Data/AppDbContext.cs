using Microsoft.EntityFrameworkCore;
using MVCPizzaria.Models;

namespace MVCPizzaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<PizzaModel> Pizzas { get; set; }
    }
}
