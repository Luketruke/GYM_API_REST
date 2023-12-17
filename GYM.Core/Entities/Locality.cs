namespace GYM.Core.Entities
{
    public class Locality : BaseEntity
    {
        public string? Description { get; set; }
        public int ProvinceId { get; set; }
        public ICollection<Dojo>? Dojos { get; set; }
    }
}
