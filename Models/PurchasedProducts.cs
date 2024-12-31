using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class PurchasedProducts
    {
        [Key]
        public int Id { get; set; }
        public int UserMasterId { get; set; }
        public UserMaster? UserMaster { get; set; }
        public int ProductId { get; set; }
        public Products? Products { get; set; }
        public int ProductCount { get; set; }
        public double TotalValue { get;set; }
    }
}
