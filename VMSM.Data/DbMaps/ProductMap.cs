using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Category).HasConversion<string>();
            builder.Property(x => x.PreviousPurchasePrice).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Profit).HasColumnType("decimal(18,4)");
            builder.Property(x => x.PurchasePrice).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Rebate).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Tax).HasColumnType("decimal(18,4)");
            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}
