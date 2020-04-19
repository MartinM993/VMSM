using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");
            
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.VendingMachines);
            builder.HasIndex(x => new { x.FieldWorkerId, x.Day }).IsUnique();
        }
    }
}
