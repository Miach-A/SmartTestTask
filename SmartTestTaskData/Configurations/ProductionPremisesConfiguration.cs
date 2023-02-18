using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestTaskModel;

namespace SmartTestTaskData.Configurations
{
    internal class ProductionPremisesConfiguration : IEntityTypeConfiguration<ProductionPremises>
    {
        public void Configure(EntityTypeBuilder<ProductionPremises> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128);
            //builder.HasMany(x => x.Contracts).WithOne(x => x.ProductionPremises).HasForeignKey(x => x.ProductionPremisesId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
