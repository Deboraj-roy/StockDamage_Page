using Microsoft.EntityFrameworkCore;
using StockDamage.Web.Models;

namespace StockDamage.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
     
        }

        public DbSet<Godown> Godown { get; set; } = null!;
        public DbSet<SubItemCode> SubItemCode { get; set; } = null!;
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<Currency> Currency { get; set; } = null!;
        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<StockDamage.Web.Models.StockDamage> StockDamage { get; set; } = null!; // optional direct mapping
        //public DbSet<StockDamageVoucher> StockDamageVoucher { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
