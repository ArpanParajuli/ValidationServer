namespace ValidationServer.Models.Students
{
    public class Guardian
    {
        public int Id { get; set; } 

        public string? GuardianFullName { get; set; }
        public string? GuardianRelation { get; set; }
        public string? GuardianOccupation { get; set; }
        public string? GuardianMobileNumber { get; set; }
        public string? GuardianEmail { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
