using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Requests
{
    public class ProductSearchRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
