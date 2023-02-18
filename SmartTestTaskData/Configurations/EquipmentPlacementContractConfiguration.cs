using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestTaskModel;

namespace SmartTestTaskData.Configurations
{
    internal class EquipmentPlacementContractConfiguration : IEntityTypeConfiguration<EquipmentPlacementContract>
    {
        public void Configure(EntityTypeBuilder<EquipmentPlacementContract> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductionPremises).WithMany(x => x.Contracts).HasForeignKey(x => x.ProductionPremisesId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.TypeOfEquipment).WithMany(x => x.Contracts).HasForeignKey(x => x.TypeOfEquipmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
