using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string PaymentMethodUses { get; set; }
        public float TotalValue { get; set; }
        public int DiscountAppliedId { get; set; }
        public DiscountTable? DiscountTable { get; set; }
        public int FinalValue { get; set; }
    }
}
