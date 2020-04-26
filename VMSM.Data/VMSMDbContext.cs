using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VMSM.Contracts.Entities;
using VMSM.Data.DbMaps;

namespace VMSM.Data
{
    public class VMSMDbContext : IdentityDbContext
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
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new VehicleMap());
            builder.ApplyConfiguration(new VendingMachineMap());
            builder.ApplyConfiguration(new VendingMachineScheduleMap());
            builder.ApplyConfiguration(new IncomeMap());
            builder.ApplyConfiguration(new VendingMachineProductPriceMap());
            builder.ApplyConfiguration(new VendingMachineProductMap());

            base.OnModelCreating(builder);
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Defect> Defect { get; set; }
        public DbSet<FieldWorkerProduct> FieldWorkerProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<StorageExport> StorageExport { get; set; }
        public DbSet<StorageImport> StorageImport { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VendingMachine> VendingMachine { get; set; }
        public DbSet<VendingMachineSchedule> VendingMachineSchedule { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<VendingMachineProductPrice> VendingMachineProductPrice { get; set; }
        public DbSet<VendingMachineProduct> VendingMachineProduct { get; set; }
    }
}
