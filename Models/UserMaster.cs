using System.ComponentModel.DataAnnotations.Schema;

namespace VisionStore.Models
{
    public class UserMaster
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmailId { get; set; }
        public string UserContactNo { get; set; }
        public string Password { get; set; }
        public string UserSecreteQuestion { get; set; }
        public string UserSecreteAnswer { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; } 
        public Roles? Role { get; set; }

    }
}
