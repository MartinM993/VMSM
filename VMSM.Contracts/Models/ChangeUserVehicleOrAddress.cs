using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Models
{
    public class ChangeUserVehicleOrAddress
    {
        [Required]
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int? VehicleId { get; set; }
    }
}
