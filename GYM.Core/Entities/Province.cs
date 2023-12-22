namespace GYM.Core.Entities
{
    public class Province : BaseEntity
    {
        public string? Description { get; set; }
        // Navigation properties
        public ICollection<Dojo>? Dojos { get; set; }
    }
}
