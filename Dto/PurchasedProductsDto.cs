using VisionStore.Models;

namespace VisionStore.Dto
{
    public class PurchasedProductsDto
    {
        public int UserMasterId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
