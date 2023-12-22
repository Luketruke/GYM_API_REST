using GYM.Core.Enumerators;

namespace GYM.Core.Entities
{
    public class Security : BaseEntity
    {
        public string? User {  get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserTypeEnum Role { get; set; }

        // Properties for relationships
        public int DojoId { get; set; }
    }
}
