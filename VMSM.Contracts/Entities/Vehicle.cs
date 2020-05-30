using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Entities
{
    public class Vehicle : Entity
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public virtual string Brand { get; set; }
        [Required]
        public virtual string Model { get; set; }
        [Required]
        public virtual string RegistrationPlate { get; set; }
    }
}