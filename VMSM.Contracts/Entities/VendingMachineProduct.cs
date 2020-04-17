namespace VMSM.Contracts.Entities
{
    public class VendingMachineProduct : Entity
    {
        public VendingMachine VendingMachine { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
