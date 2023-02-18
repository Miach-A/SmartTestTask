using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestTaskModel;

namespace SmartTestTaskData.Configurations
{
    internal class TypeOfEquipmentConfiguration : IEntityTypeConfiguration<TypeOfEquipment>
    {
        public void Configure(EntityTypeBuilder<TypeOfEquipment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128);
            //builder.HasMany(x => x.Contracts).WithOne().HasForeignKey(x => x.TypeOfEquipmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
