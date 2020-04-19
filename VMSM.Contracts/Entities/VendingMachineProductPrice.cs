using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class VendingMachineProductPrice : Entity
    {
        public int VendingMachineId { get; set; }
        [Required]
        public VendingMachine VendingMachine { get; set; }
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
