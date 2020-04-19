using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class StorageImportMap : IEntityTypeConfiguration<StorageImport>
    {
        public void Configure(EntityTypeBuilder<StorageImport> builder)
        {
            builder.ToTable("StorageImports");
            
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product);
        }
    }
}
