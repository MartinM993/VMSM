using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Role).HasConversion<string>();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasOne(x => x.Address);
            builder.HasOne(x => x.Vehicle);
        }
    }
}
