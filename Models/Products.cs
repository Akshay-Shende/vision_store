using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductFeature { get; set; }
        public int ProductManufacturer { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public string ProductSize { get; set; }
        public string ProductSubCategory { get; set; }
        public int ProductUnit { get; set; }
        public int ProductInventoryLevel { get; set;}
        public long ProductUnitPrice { get; set; }
        public string ProductPriceCurrency { get; set; }
        public int ProductInventoryThreshold { get; set; }
        public string ProductImageUrl { get; set; }
     
    }
}
