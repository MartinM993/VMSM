using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class VendingMachineSearchRequest
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public VendingMachineCategory? Category { get; set; }

    }
}
