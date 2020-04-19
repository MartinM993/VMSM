using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineScheduleMap : IEntityTypeConfiguration<VendingMachineSchedule>
    {
        public void Configure(EntityTypeBuilder<VendingMachineSchedule> builder)
        {
            builder.ToTable("VendingMachineSchedules");

            builder.HasKey(x => new { x.VendingMachineId, x.ScheduleId});
            builder.HasOne(x => x.VendingMachine)
                   .WithMany(x => x.Schedules)
                   .HasForeignKey(x => x.VendingMachineId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Schedule)
                   .WithMany(x => x.VendingMachines)
                   .HasForeignKey(x => x.ScheduleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
