using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter valid email!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and comfirm password do not match!")]
        public string ConfirmPassword { get; set; }
        [Required]
        public int AddressId { get; set; }
        public int? VehicleId { get; set; }
    }
}
