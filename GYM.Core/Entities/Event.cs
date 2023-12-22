namespace GYM.Core.Entities
{
    public class Event : BaseEntity
    {
        public string? Description { get; set; }
        public DateTime EventDate { get; set; } 
        public string? Remarks { get; set; }
        public int EventStatus { get; set; }

        // Navigation properties
        public ICollection<Fighter>? Fighters { get; set; }
    }
}
