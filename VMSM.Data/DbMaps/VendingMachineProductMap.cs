using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineProductMap : IEntityTypeConfiguration<VendingMachineProduct>
    {
        public void Configure(EntityTypeBuilder<VendingMachineProduct> builder)
        {
            builder.ToTable("VendingMachineProducts");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.VendingMachine);
            builder.HasOne(x => x.Product);
        }
    }
}
