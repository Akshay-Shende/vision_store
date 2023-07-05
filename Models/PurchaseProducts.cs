namespace VisionStore.Models
{
    public class PurchaseProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products? Products { get; set; }
        public int PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
        public int PurchasedUnits { get; set; }
        public string DeliveryInstruction { get; set; }
    }
}
