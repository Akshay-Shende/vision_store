using System.ComponentModel.DataAnnotations;

namespace VisionStore.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManuId { get; set; }
        public string ManufacturerName { get; set;}
        public string ManufacturerDescription { get; set;}
        public string ManuCity { get; set;}
        public char ManuGrade { get; set;}
        public string ManuCountry { get; set;}
    }
}
