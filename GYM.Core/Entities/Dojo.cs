using System.ComponentModel.DataAnnotations.Schema;

namespace GYM.Core.Entities
{
    public class Dojo : BaseEntity
    {
        public string? Name { get; set; }
        public string? InstructorName { get; set; }
        public string? InstructorPhone { get; set; }
        public string? DojoPhone { get; set; }
        public string? Address { get; set; }
        public string? Remarks { get; set; }

        // Properties for relationships
        public int? LocalityId { get; set; }
        public int? ProvinceId { get; set; }

        // Navigation properties
        [ForeignKey("LocalityId")]
        public Locality? Locality { get; set; }

        [ForeignKey("ProvinceId")]
        public Province? Province { get; set; }

        public ICollection<Fighter>? Fighters { get; set; }
    }
}
