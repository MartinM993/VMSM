using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class FieldWorkerProductMap : IEntityTypeConfiguration<FieldWorkerProduct>
    {
        public void Configure(EntityTypeBuilder<FieldWorkerProduct> builder)
        {
            builder.ToTable("FieldWorkerProduct");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.FieldWorker);
            builder.HasOne(x => x.Product);
            builder.HasIndex(x => new { x.FieldWorkerId, x.ProductId }).IsUnique();
        }
    }
}
