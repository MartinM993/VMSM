﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMSM.Contracts.Entities;

namespace VMSM.Data.DbMaps
{
    public class VendingMachineMap : IEntityTypeConfiguration<VendingMachine>
    {
        public void Configure(EntityTypeBuilder<VendingMachine> builder)
        {
            builder.ToTable("VendingMachines");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Category).HasConversion<string>();
            builder.HasMany(x => x.VendingMachineSchedules);
            builder.HasOne(x => x.Address);
        }
    }
}
