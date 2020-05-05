using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class StorageImport : Entity
    {
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public virtual int Quantity { get; set; }
    }
}
