using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class ScheduleSearchRequest
    {
        public Day? Day { get; set; }
        public int? FieldWorkerId { get; set; }
        public string FieldWorkerName { get; set; }
        public string FieldWorkerLastName { get; set; }
    }
}
