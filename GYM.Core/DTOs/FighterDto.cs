using GYM.Core.Entities;
using GYM.Core.Enumerators;

namespace GYM.Core.DTOs
{
    public class FighterDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public int? NIC { get; set; }
        public decimal? Weight { get; set; }
        public int Height { get; set; }
        public int? Age { get; set; }
        public int? FightCount { get; set; }
        public int? DojoId { get; set; }
        public string? Modality { get; set; }
        public string? Category { get; set; }
        public string? Gender { get; set; }
        public int? EventId { get; set; }
        public string? Remarks { get; set; }
        public int Status { get; set; }
    }
}
