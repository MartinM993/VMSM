using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineProductPriceMap : IEntityTypeConfiguration<VendingMachineProductPrice>
    {
        public void Configure(EntityTypeBuilder<VendingMachineProductPrice> builder)
        {
            builder.ToTable("VendingMachineProductPrices").HasKey(x => x.Id);
        }
    }
}
