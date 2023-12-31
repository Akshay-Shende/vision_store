﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime CartTimestamp { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products? Products { get; set; }
        public int SelectedUnits { get; set; }

        [ForeignKey("UserMaster")]
        public int UserMasterId { get; set; }
        public UserMaster? UserMaster { get; set; }

    }
}
