using GYM.Core.Enumerators;

namespace GYM.Core.Entities
{
    public class UserLogin : BaseEntity
    {
        public string? User { get; set; }
        public string? Password { get; set; }
        public UserTypeEnum Role { get; set; }
    }
}
