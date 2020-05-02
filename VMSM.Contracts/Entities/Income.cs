using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Income : Entity
    {
        public virtual int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        [Required]
        public virtual int CollectedIncome { get; set; }
    }
}
