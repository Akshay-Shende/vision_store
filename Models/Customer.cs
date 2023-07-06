using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public int CustomerPin { get; set; }
        public string CustomerCountry { get; set; }
        public int PaymentMethodId { get; set; }
        PreferredPaymentMethod? PreferredPaymentMethod { get; set; }
        public string CustomerPassword { get; set; }
    }
}
