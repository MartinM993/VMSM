using System.Collections.Generic;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class VendingMachine : Entity
    {
        public VendingMachine()
        {
            Schedule = new List<Schedule>();
        }

        public virtual string Name { get; set; }
        public virtual string Model { get; set; }
        public virtual int ProductionYear { get; set; }
        public virtual string Code { get; set; }
        public virtual VendingMachineCategory Category { get; set; }
        public virtual Address Location { get; set; }
        public virtual int Income { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int NumberOfDefects { get; set; }
        public virtual int CostOfDefects { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }

    }
}
