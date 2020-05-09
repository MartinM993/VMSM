using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VMSM.Contracts.Entities;
using VMSM.Data.DbMaps;

namespace VMSM.Data
{
    public class VMSMDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public VMSMDbContext(DbContextOptions<VMSMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMap());
            builder.ApplyConfiguration(new DefectMap());
            builder.ApplyConfiguration(new FieldWorkerProductMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new ScheduleMap());
            builder.ApplyConfiguration(new StorageExportMap());
            builder.ApplyConfiguration(new StorageImportMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new VehicleMap());
            builder.ApplyConfiguration(new VendingMachineMap());
            builder.ApplyConfiguration(new VendingMachineScheduleMap());
            builder.ApplyConfiguration(new IncomeMap());
            builder.ApplyConfiguration(new VendingMachineProductPriceMap());
            builder.ApplyConfiguration(new VendingMachineProductMap());

            base.OnModelCreating(builder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Defect> Defects { get; set; }
        public DbSet<FieldWorkerProduct> FieldWorkerProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StorageExport> StorageExports { get; set; }
        public DbSet<StorageImport> StorageImports { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VendingMachine> VendingMachines { get; set; }
        public DbSet<VendingMachineSchedule> VendingMachineSchedules { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<VendingMachineProductPrice> VendingMachineProductPrices { get; set; }
        public DbSet<VendingMachineProduct> VendingMachineProducts { get; set; }
    }
}
