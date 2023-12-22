using GYM.Core.Enumerators;

namespace GYM.Core.Entities

{
    public class Fight : BaseEntity
    {
        public Fighter? Fighter1 { get; set; }
        public Fighter? Fighter2 { get; set; }
        public Dojo? Dojo { get; set; }
        public ModalityEnum Modality { get; set; }
        public string? Remarks { get; set; }
        public int EventId { get; set; }
    }
}
