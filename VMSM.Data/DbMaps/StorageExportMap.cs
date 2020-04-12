using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class StorageExportMap : IEntityTypeConfiguration<StorageExport>
    {
        public void Configure(EntityTypeBuilder<StorageExport> builder)
        {
            builder.ToTable("StorageExports").HasKey(x => x.Id);
        }
    }
}
