namespace GYM.Core.DTOs
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Remarks { get; set; }
        public string StatusEvent { get; set; }
        public int StatusEventId { get; set; }
    }
}
