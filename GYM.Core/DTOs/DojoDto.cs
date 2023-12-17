namespace GYM.Core.DTOs
{
    public class DojoDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortAddress { get; set; }
        public string? FullAddress { get; set; }
        public string? InstructorName { get; set; }
        public string? InstructorPhone { get; set; }
        public string? DojoPhone { get; set; }
        public string? Remarks { get; set; }
        public int LocalityId { get; set; }
        public int ProvinceId { get; set; }
        public string? LocalityName { get; set; }
        public string? ProvinceName { get; set; }
        public int Status { get; set; }
    }
}
