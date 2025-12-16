using ValidationServer.Models.Students;

namespace ValidationServer.DTOs
{
    public class GuardianDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string? Occupation { get; set; }
        public string? Designation { get; set; }
        public string? Organization { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Relation { get; set;}

    }
}