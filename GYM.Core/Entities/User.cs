using GYM.Core.Enumerators;

namespace GYM.Core.Entities
{
    public class User : BaseEntity
    {
        public int Code { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserTypeEnum Role { get; set; }
        public Dojo? Dojo { get; set; }
        public int Status { get; set; }
    }
}
