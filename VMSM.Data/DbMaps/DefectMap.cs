using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class DefectMap : IEntityTypeConfiguration<Defect>
    {
        public void Configure(EntityTypeBuilder<Defect> builder)
        {
            builder.ToTable("Defects");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cost).HasColumnType("decimal(18,4)");
            builder.HasOne(x => x.VendingMachine);
        }
    }
}