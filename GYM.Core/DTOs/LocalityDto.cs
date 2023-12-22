using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class LocalityDto : BaseEntity
    {
        public string? Description { get; set; }
        public int ProvinceId { get; set; }
    }
}
