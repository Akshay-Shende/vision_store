﻿using VisionStore.Models;

namespace VisionStore.Dto
{
    public class LoginDto
    {
        public int userId { get; set; }
        public string password { get; set; }
        public string Role     { get; set; }
        public UserMaster UserMaster { get; set; }
    }
}
