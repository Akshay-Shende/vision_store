using VisionStore.Models;

namespace VisionStore.Dto
{
    public class CartDto
    {
        public DateTime CartTimestamp { get; set; }
        public int ProductId { get; set; }
        public Products? products { get; set; }
        public int SelectedUnits { get; set; }
        public int UserMasterId { get; set; }
        public UserMaster? UserMaster { get; set; }
    }
}
