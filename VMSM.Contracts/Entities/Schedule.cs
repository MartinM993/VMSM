using System.Collections.Generic;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
            VendingMachines = new List<VendingMachine>();
        }

        public virtual User AssignedBy { get; set; }
        public virtual User FieldWorker { get; set; }
        public virtual Day Day { get; set; }
        public virtual ICollection<VendingMachine> VendingMachines { get; set; }
    }
}
