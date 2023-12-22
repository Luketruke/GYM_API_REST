using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class UserDto : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
