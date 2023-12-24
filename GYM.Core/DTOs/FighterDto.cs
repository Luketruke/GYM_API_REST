using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class FighterDto : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public int? NIC { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public int? Age { get; set; }
        public int? FightCount { get; set; }
        public string? Modality { get; set; }
        public string? Category { get; set; }
        public string? Gender { get; set; }
        public string? Remarks { get; set; }

        // Properties for relationships
        public int? DojoId { get; set; }
        public int? EventId { get; set; }
        public string? DojoName { get; set; }
        public string? EventName { get; set; }

        // Navigation property
        public DojoDto? Dojo { get; set; }
        public EventDto? Event { get; set; }
    }
}
