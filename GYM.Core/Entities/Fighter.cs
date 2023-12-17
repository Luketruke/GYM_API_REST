using GYM.Core.Enumerators;

namespace GYM.Core.Entities
{
    public class Fighter : BaseEntity
    {
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public decimal Weight { get; set; }
        public int Height { get; set; }
        public int IDNumber { get; set; }
        public int Age { get; set; }
        public int FightCount { get; set; }
        public int EventId { get; set; }
        public Dojo Dojo { get; set; }
        public Modality Modality { get; set; }
        public Category Category { get; set; }
        public Gender Gender { get; set; }
        public string Remarks { get; set; }
        public DateTime InformationDate { get; set; }
        public int Status { get; set; }
    }
}
