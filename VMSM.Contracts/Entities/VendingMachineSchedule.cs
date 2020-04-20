namespace VMSM.Contracts.Entities
{
    public class VendingMachineSchedule
    {
        public virtual int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
