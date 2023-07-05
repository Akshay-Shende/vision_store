using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class PreferredPaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}
