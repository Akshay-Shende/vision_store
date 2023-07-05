namespace VisionStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime CartTimestamp { get; set; }
        public int ProductId { get; set; }
        public Products? products { get; set; }
        public int SelectedUnits { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
