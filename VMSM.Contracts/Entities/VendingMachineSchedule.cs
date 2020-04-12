namespace VMSM.Contracts.Entities
{
    public class VendingMachineSchedule
    {
        public virtual VendingMachine VendingMachine { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
