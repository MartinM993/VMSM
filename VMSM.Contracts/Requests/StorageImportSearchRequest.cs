namespace VMSM.Contracts.Requests
{
    public class StorageImportSearchRequest
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? StorageWorkerId { get; set; }
        public int? ProductId { get; set; }
    }
}
