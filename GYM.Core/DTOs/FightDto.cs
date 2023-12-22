using GYM.Core.Entities;

namespace GYM.Core.DTOs
{
    public class FightDto : BaseEntity
    {
        public int Code { get; set; }
        public string? Remarks { get; set; }
    }
}
