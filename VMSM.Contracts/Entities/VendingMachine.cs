using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class VendingMachine : Entity
    {
        public VendingMachine()
        {
            VendingMachineSchedules = new List<VendingMachineSchedule>();
        }

        public virtual string Name { get; set; }
        public virtual string Model { get; set; }
        public virtual int ProductionYear { get; set; }
        [Required]
        public virtual string Code { get; set; }
        public virtual VendingMachineCategory Category { get; set; }
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual int Income { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int NumberOfDefects { get; set; }
        public virtual int CostOfDefects { get; set; }
        public int MachineCost { get; set; }
        public virtual ICollection<VendingMachineSchedule> VendingMachineSchedules { get; set; }
    }
}
