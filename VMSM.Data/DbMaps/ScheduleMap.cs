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
            builder.Property(x => x.Day).HasConversion<string>();
            builder.HasMany(x => x.VendingMachineSchedules).WithOne(y => y.Schedule);
            builder.HasOne(x => x.FieldWorker);
            builder.HasIndex(x => new { x.FieldWorkerId, x.Day }).IsUnique();
        }
    }
}
