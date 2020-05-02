using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Defect : Entity
    {
        public virtual int VendingMachineId { get; set; }
        [Required]
        public virtual VendingMachine VendingMachine { get; set; }
        [Required]
        public virtual decimal Cost { get; set; }
        public virtual string Description { get; set; }
    }
}
