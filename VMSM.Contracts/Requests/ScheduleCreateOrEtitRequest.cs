using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class ScheduleCreateOrEtitRequest
    {
        public ScheduleCreateOrEtitRequest()
        {
            VendingMachineIds = new int[] { };
        }

        public int? ScheduleId { get; set; }
        [Required]
        public virtual int FieldWorkerId { get; set; }
        [Required]
        public virtual Day Day { get; set; }
        public virtual IEnumerable<int> VendingMachineIds { get; set; }
    }
}
