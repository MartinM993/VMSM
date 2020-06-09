using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Defect : Entity
    {
        public virtual int VendingMachineId { get; set; }
        public virtual VendingMachine VendingMachine { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage = "Cost value should be between 0 and 100000")]
        public virtual decimal Cost { get; set; }
        public virtual string Description { get; set; }
    }
}
