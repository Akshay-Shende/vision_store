namespace VisionStore.Dto
{
    public class DiscountTableDto
    {
        public string DiscountCouponCode { get; set; }
        public string DiscountCouponDescription { get; set; }
        public int DiscountCouponPercentage { get; set; }
        public DateTime DiscountCouponCodeStart { get; set; }
        public DateTime DiscountCouponCodeValidTill { get; set; }
    }
}
