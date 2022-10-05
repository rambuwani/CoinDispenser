using Coin.Dispenser.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Coin.Dispenser.DataAccess
{
    public class CoinDispenserDataContext : DbContext
    {
        public CoinDispenserDataContext()
        {

        }
        public CoinDispenserDataContext(DbContextOptions<CoinDispenserDataContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Database=CoinDispenserDb;Trusted_Connection=True;");
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
            //Picks up all configurations defined in the assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Coin> Coins { get; set; }
        public DbSet<CoinCheckBox> CoinCheckBoxes { get; set; }
    }
}
