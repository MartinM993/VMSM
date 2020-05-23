namespace VMSM.Contracts.Models
{
    public class CustomActionResult
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public int? EntityId { get; set; }
    }
}
