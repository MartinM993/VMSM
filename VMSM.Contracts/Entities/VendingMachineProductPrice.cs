namespace VMSM.Contracts.Entities
{
    public class VendingMachineProductPrice : Entity
    {
        public VendingMachine VendingMachine { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }
    }
}
