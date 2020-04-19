using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
            VendingMachines = new List<VendingMachineSchedule>();
        }

        public int FieldWorkerId { get; set; }
        [Required]
        public virtual User FieldWorker { get; set; }
        [Required]
        public virtual Day Day { get; set; }
        public virtual ICollection<VendingMachineSchedule> VendingMachines { get; set; }
    }
}
