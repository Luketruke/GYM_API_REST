﻿namespace GYM.Core.Entities
{
    public class Locality : BaseEntity
    {
        public string? Description { get; set; }
        public int ProvinceId { get; set; }

        // Navigation properties
        public ICollection<Dojo>? Dojos { get; set; }
    }
}
