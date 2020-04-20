using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Income : Entity
    {
        public virtual int VendingMachineId { get; set; }
        [Required]
        public virtual VendingMachine VendingMachine { get; set; }
        public virtual int CollectedIncomeId { get; set; }
        [Required]
        public virtual int CollectedIncome { get; set; }
    }
}
