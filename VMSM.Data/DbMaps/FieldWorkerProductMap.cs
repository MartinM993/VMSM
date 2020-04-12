using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class FieldWorkerProductMap : IEntityTypeConfiguration<FieldWorkerProduct>
    {
        public void Configure(EntityTypeBuilder<FieldWorkerProduct> builder)
        {
            builder.ToTable("FieldWorkerProduct").HasKey(x => x.Id);

            builder.HasIndex(x => new { x.FieldWorker, x.Product }).IsUnique();
        }
    }
}
