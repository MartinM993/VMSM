using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class StorageExportMap : IEntityTypeConfiguration<StorageExport>
    {
        public void Configure(EntityTypeBuilder<StorageExport> builder)
        {
            builder.ToTable("StorageExports");
            
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.FieldWorker);
            builder.HasOne(x => x.Product);
        }
    }
}
