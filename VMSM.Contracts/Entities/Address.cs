using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Address : Entity
    {
        [Required]
        public virtual string Town { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
    }
}
