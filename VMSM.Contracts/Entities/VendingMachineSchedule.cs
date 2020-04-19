namespace VMSM.Contracts.Entities
{
    public class VendingMachineSchedule
    {
        public int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
