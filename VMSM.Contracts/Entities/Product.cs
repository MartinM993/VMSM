using System.ComponentModel.DataAnnotations;
using VMSM.Contracts.Enums;

namespace VMSM.Contracts.Entities
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }
        [Required]
        public virtual string Code { get; set; }
        public virtual ProductCategory Category { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Quantity value should be between 0 and 100000")]
        public virtual decimal PurchasePrice { get; set; }
        public virtual decimal PreviousPurchasePrice { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity value should be between 0% and 100%")]
        public virtual decimal Tax { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity value should be between 0% and 100%")]
        public virtual decimal Rebate { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity value should be between 0% and 100%")]
        public virtual decimal Profit { get; set; }
        public virtual int SellingPrice
        {
            get
            {
                var purchasePriceWithRebate = PurchasePrice - PurchasePrice * (Rebate / 100);
                var purchasePriceWithTax = purchasePriceWithRebate + purchasePriceWithRebate * (Tax / 100);

                return decimal.ToInt32(decimal.Round(purchasePriceWithTax + purchasePriceWithTax * (Profit / 100)));
            }
        }

        [Required]
        [Range(1, 100000, ErrorMessage = "Quantity value should be at least 1")]
        public virtual int Quantity { get; set; }
        public virtual int StorageQuantity { get; set; }
        public virtual int Weight { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Selling Pieces value should be at least 1")]
        public virtual int SellingPieces { get; set; }
        public virtual int PriceByPiece
        {
            get
            {
                if (SellingPieces > 1)
                {
                    return decimal.ToInt32(decimal.Round(SellingPrice / SellingPieces));
                }

                return SellingPrice;
            }
        }
    }
}
