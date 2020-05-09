using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Enums;

namespace VMSM.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<VMSMDbContext>();
            context.Database.EnsureCreated();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole<int> { Name = Role.Admin.ToString(), NormalizedName = Role.Admin.ToString().ToUpper() });
                context.Roles.Add(new IdentityRole<int> { Name = Role.FieldWorker.ToString(), NormalizedName = Role.FieldWorker.ToString().ToUpper() });
                context.Roles.Add(new IdentityRole<int> { Name = Role.StorageWorker.ToString(), NormalizedName = Role.StorageWorker.ToString().ToUpper() });
                context.Roles.Add(new IdentityRole<int> { Name = Role.OfficeWorker.ToString(), NormalizedName = Role.OfficeWorker.ToString().ToUpper() });

                context.SaveChanges();
            }

            if (!context.Addresses.Any())
            {
                context.Addresses.Add(new Address
                {
                    Town = "Kumanovo",
                    ZipCode = "1300",
                    Line1 = "Test Super admin addres",
                    CreatedBy = 1,
                    DateCreated = DateTime.UtcNow
                });
            }

            if (!context.AppUsers.Any())
            {
                var superAdmin = new AppUser();
                var passwordHasher = new PasswordHasher<AppUser>();
                var hashedPassword = passwordHasher.HashPassword(superAdmin, "admin123");

                //superAdmin.Id = (int)Role.Admin;
                superAdmin.Email = "superadmin@gmail.com";
                superAdmin.Name = "Super";
                superAdmin.LastName = "Admin";
                superAdmin.MiddleName = "M";
                superAdmin.SecurityStamp = "be0aefcf-bf66-40b7-a3a6-d42f58ef0beb";
                superAdmin.UserName = superAdmin.Email;
                superAdmin.NormalizedUserName = superAdmin.Email.ToUpper();
                superAdmin.NormalizedEmail = superAdmin.Email.ToUpper();
                superAdmin.PasswordHash = hashedPassword;
                superAdmin.UserRole = Role.Admin;
                superAdmin.AddressId = 1;
                superAdmin.CreatedBy = (int)Role.Admin;
                superAdmin.DateCreated = DateTime.UtcNow;

                context.AppUsers.Add(superAdmin);
                context.SaveChanges();
            }

            if (!context.UserRoles.Any())
            {
                context.UserRoles.Add(new IdentityUserRole<int>() { UserId = 4, RoleId = 9 });
                context.SaveChanges();
            }
        }
    }
}
