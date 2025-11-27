using ValidationServer.Models.Students;

namespace ValidationServer.Models.Students
{
    public class Scholarship
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? ProviderName { get; set; }
        public decimal? Amount { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
