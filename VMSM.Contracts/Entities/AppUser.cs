using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;
using VMSM.Contracts.Interfaces;

namespace VMSM.Contracts.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        [Required]
        public virtual Role UserRole { get; set; }
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public void SetAudit(int? userId)
        {
            if (Id == 0)
            {
                CreatedBy = userId;
                DateCreated = DateTime.UtcNow;
            }

            ModifiedBy = userId;
            DateModified = DateTime.UtcNow;
        }

    }
}