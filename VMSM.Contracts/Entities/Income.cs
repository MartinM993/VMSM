namespace VMSM.Contracts.Entities
{
    public class Income : Entity
    {
        public VendingMachine VendingMachine { get; set; }
        public int CollectedIncome { get; set; }
    }
}
