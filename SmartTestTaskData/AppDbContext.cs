using Microsoft.EntityFrameworkCore;
using SmartTestTaskModel;

namespace SmartTestTaskData
{
    public class AppDbContext : DbContext
    {
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContract { get; set; }

        public DbSet<TypeOfEquipment> TypeOfEquipment { get; set; }

        public DbSet<ProductionPremises> ProductionPremises { get; set; }

    }
}