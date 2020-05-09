using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class Schedule : Entity
    {
        public Schedule()
        {
            VendingMachineSchedules = new List<VendingMachineSchedule>();
        }

        public virtual int FieldWorkerId { get; set; }
        public virtual AppUser FieldWorker { get; set; }
        [Required]
        public virtual Day Day { get; set; }
        public virtual ICollection<VendingMachineSchedule> VendingMachineSchedules { get; set; }
    }
}
