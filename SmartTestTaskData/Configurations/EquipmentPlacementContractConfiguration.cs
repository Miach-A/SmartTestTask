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
            builder.HasOne(x => x.ProductionPremises).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.TypeOfEquipment).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
