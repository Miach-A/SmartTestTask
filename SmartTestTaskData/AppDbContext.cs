using Microsoft.EntityFrameworkCore;
using SmartTestTaskData.Extensions;
using SmartTestTaskModel;
using System.Reflection;

namespace SmartTestTaskData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options
            ) : base(options)
        {
        }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContract { get; set; }

        public DbSet<TypeOfEquipment> TypeOfEquipment { get; set; }

        public DbSet<ProductionPremises> ProductionPremises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

    }
}