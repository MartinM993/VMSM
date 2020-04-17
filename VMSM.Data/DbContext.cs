using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VMSM.Contracts.Entities;
using VMSM.Data.DbMaps;

namespace VMSM.Data
{
    public class DbContext : IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
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

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Defect> Defect { get; set; }
        public virtual DbSet<FieldWorkerProduct> FieldWorkerProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<StorageExport> StorageExport { get; set; }
        public virtual DbSet<StorageImport> StorageImport { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VendingMachine> VendingMachine { get; set; }
        public virtual DbSet<VendingMachineSchedule> VendingMachineSchedule { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<VendingMachineProductPrice> VendingMachineProductPrice { get; set; }
        public virtual DbSet<VendingMachineProduct> VendingMachineProduct { get; set; }
    }
}
