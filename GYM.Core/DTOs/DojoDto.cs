using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class DojoDto : BaseEntity
    {
        public string? Name { get; set; }
        public string? ShortAddress { get; set; }
        public string? FullAddress { get; set; }
        public string? InstructorName { get; set; }
        public string? InstructorPhone { get; set; }
        public string? DojoPhone { get; set; }
        public string? Remarks { get; set; }
        public string? LocalityName { get; set; }
        public string? ProvinceName { get; set; }

        // Properties for relationships
        public int LocalityId { get; set; }
        public int ProvinceId { get; set; }

        // Navigation property
        public LocalityDto? Locality { get; set; }
        public ProvinceDto? Province { get; set; }
    }
}
