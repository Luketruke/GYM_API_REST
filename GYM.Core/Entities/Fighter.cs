using GYM.Core.Enumerators;

namespace GYM.Core.Entities
{
    public class Fighter : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NIC { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public int? Age { get; set; }
        public int? FightCount { get; set; }    
        public string? Remarks { get; set; }
        public ModalityEnum? Modality { get; set; }
        public CategoryEnum? Category { get; set; }
        public GenderEnum? Gender { get; set; }
        public int? Status { get; set; }

        // New properties for relationships
        public int? DojoId { get; set; }
        public int? EventId { get; set; }

        // Navigation properties
        public Dojo? Dojo { get; set; }     
        public Event? Event { get; set; }
    }
}
