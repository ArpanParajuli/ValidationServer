namespace ValidationServer.Models.Students
{
    public class Citizenship
    {
        public int Id { get; set; }
        public string CitizenshipNumber { get; set; } = string.Empty;
        public DateOnly CitizenshipIssueDate { get; set; }
        public string CitizenshipIssueDistrict { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
