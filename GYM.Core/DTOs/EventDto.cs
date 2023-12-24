using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class EventDto : BaseEntity
    {
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public string? Remarks { get; set; }
        public int? EventStatus { get; set; }
    }
}
