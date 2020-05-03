namespace VMSM.Contracts.Requests
{
    public class IncomeSearchRequest
    {
        public int? VendingMachineId { get; set; }
        public string VendingMachineName { get; set; }
        public string VendingMachineCode { get; set; }
    }
}
