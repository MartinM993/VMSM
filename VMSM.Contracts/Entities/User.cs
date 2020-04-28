﻿using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class User : Entity
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Password { get; set; }
        [Required]
        public virtual string PhoneNumber { get; set; }
        [Required]
        public virtual Role Role { get; set; }
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}