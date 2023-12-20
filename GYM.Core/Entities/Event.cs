namespace GYM.Core.Entities
{
    public class Event : BaseEntity
    {
        public string Description { get; set; }
        public DateTime EventDate { get; set; } 
        public string Remarks { get; set; }
        public string StatusEvent { get; set; }
        public int StatusEventId { get; set; }
        public ICollection<Fighter>? Fighters { get; set; }
    }
}
