using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class DeliveryMethods
    {
        [Key]
        public int DeliveryMethodId { get; set;}
        public string DeliveryMethodDescription { get; set;}
    }
}
