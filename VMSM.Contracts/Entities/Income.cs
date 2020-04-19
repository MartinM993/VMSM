using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Income : Entity
    {
        public int VendingMachineId { get; set; }
        [Required]
        public VendingMachine VendingMachine { get; set; }
        public int CollectedIncomeId { get; set; }
        [Required]
        public int CollectedIncome { get; set; }
    }
}
