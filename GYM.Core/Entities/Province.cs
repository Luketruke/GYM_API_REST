namespace GYM.Core.Entities
{
    public class Province : BaseEntity
    {
        public string? Description { get; set; }
        public ICollection<Dojo>? Dojos { get; set; }
    }
}
