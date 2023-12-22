using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class SecurityDto : BaseEntity
    {
        public string? User { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int DojoId { get; set; }
        public string? Role { get; set; }
    }
}