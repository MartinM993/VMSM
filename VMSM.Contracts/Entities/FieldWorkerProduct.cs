using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class FieldWorkerProduct : Entity
    {
        public int FieldWorkerId { get; set; }
        [Required]
        public virtual User FieldWorker { get; set; }
        public int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual int Quantity { get; set; }
    }
}
