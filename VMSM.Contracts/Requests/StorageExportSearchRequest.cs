namespace VMSM.Contracts.Requests
{
    public class StorageExportSearchRequest
    {
        public string FieldWorkerName { get; set; }
        public string FieldWorkerLastName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? FieldWorkerId { get; set; }
        public int? StorageWorkerId { get; set; }
        public int? ProductId { get; set; }
    }
}
