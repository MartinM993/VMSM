using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineScheduleMap : IEntityTypeConfiguration<VendingMachineSchedule>
    {
        public void Configure(EntityTypeBuilder<VendingMachineSchedule> builder)
        {
            builder.ToTable("VendingMachineSchedule");
        }
    }
}
