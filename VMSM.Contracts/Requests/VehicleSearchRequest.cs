namespace VMSM.Contracts.Requests
{
    public class VehicleSearchRequest
    {
        public string RegistrationPlate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
    }
}
