using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class VendingMachineProductPriceSearchRequest
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string VendingMachineCode { get; set; }
        public string VendingMachineName { get; set; }
        public string VendingMachineModel { get; set; }
    }
}
