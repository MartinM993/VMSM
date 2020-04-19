using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineProductPriceMap : IEntityTypeConfiguration<VendingMachineProductPrice>
    {
        public void Configure(EntityTypeBuilder<VendingMachineProductPrice> builder)
        {
            builder.ToTable("VendingMachineProductPrices");
            
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.VendingMachine);
            builder.HasOne(x => x.Product);
            builder.HasIndex(x => new { x.VendingMachineId, x.ProductId}).IsUnique();
        }
    }
}
