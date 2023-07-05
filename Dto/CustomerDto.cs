using VisionStore.Models;

namespace VisionStore.Dto
{
    public class CustomerDto
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public int CustomerPin { get; set; }
        public string CustomerCountry { get; set; }
        public int CustomerPrefferedPaymentMethod { get; set; }
        public PreferredPaymentMethod preferredPaymentMethod { get; set; }
        public string CustomerPassword { get; set; }
    }
}
