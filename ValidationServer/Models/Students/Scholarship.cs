using ValidationServer.Models.Students;

namespace ValidationServer.Models.Students
{
    public class Scholarship
    {
        // ------------ Scholarship Details ------------
        public int Id { get; set; }
        public string? ScholarshipType { get; set; }         // Government, Institutional, Private
        public string? ScholarshipProviderName { get; set; }
        public decimal? ScholarshipAmount { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
