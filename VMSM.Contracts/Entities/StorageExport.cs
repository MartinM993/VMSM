using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class StorageExport : Entity
    {
        public virtual int FieldWorkerId { get; set; }
        [Required]
        public virtual User FieldWorker { get; set; }
        public virtual int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual int Quantity { get; set; }
    }
}