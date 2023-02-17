using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartTestTaskData.Extensions;
using SmartTestTaskModel;
using System.Reflection;

namespace SmartTestTaskData
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(
            IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContract { get; set; }

        public DbSet<TypeOfEquipment> TypeOfEquipment { get; set; }

        public DbSet<ProductionPremises> ProductionPremises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql")).LogTo(Console.WriteLine, LogLevel.Information); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

    }
}