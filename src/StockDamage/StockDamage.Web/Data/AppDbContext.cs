using Microsoft.EntityFrameworkCore;
using StockDamage.Web.Models;

namespace StockDamage.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
     
        }

        public DbSet<Godown> Godowns { get; set; } = null!;
        public DbSet<SubItemCode> SubItemCodes { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<StockDamageLine> StockDamageLines { get; set; } = null!; // optional direct mapping
        public DbSet<StockDamageVoucher> StockDamageVouchers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
