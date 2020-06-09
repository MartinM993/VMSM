using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Income : Entity
    {
        public virtual int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage = "Collected Income value should be between 0 and 100000")]
        public virtual int CollectedIncome { get; set; }
    }
}
