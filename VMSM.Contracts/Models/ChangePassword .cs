using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Models
{
    public class ChangePassword 
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="The new password and comfirm password do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
