using VisionStore.Models;

namespace VisionStore.Dto
{
    public class UserMasterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmailId { get; set; }
        public string UserContactNo { get; set; }
        public string Password { get; set; }
        public string UserSecreteQuestion { get; set; }
        public string UserSecreteAnswer { get; set; }
        public int RoleId { get; set; }
        public Roles role { get; set; }
    }
}
