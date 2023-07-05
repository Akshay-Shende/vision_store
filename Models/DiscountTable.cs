using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class DiscountTable
    {
        [Key]
        public int DiscountId { get; set; }
        public string DiscountCouponCode { get; set;}
        public string DiscountCouponDescription { get; set; }
        public int DiscountCouponPercentage { get; set; }
        public DateTime DiscountCouponCodeStart { get; set; }
        public DateTime DiscountCouponCodeValidTill { get; set; }
    }
}
