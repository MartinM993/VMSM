using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class StorageImport : Entity
    {
        public int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual int Quantity { get; set; }
    }
}
