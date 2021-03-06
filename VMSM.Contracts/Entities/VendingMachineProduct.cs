﻿using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class VendingMachineProduct : Entity
    {
        public virtual int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public virtual int Quantity { get; set; }
    }
}
