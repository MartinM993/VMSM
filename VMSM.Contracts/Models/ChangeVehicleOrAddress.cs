using System.ComponentModel.DataAnnotations;

namespace VMSM.Contracts.Models
{
    public class ChangeVehicleOrAddress
    {
        [Required]
        public int EntityId { get; set; }
        public int AddressId { get; set; }
        public int? VehicleId { get; set; }
    }
}
