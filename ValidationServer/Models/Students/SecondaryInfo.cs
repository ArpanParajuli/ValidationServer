namespace ValidationServer.Models.Students
{
    public class SecondaryInfo : BaseEntity
    {
        //public int Id { get; set; }
        public string? MiddleName { get; set; }
        public string? AlternateEmail { get; set; }
        public string? SecondaryMobile { get; set; }
        public string? BloodGroup { get; set; }    // A+, O-, etc.
        public string? MaritalStatus { get; set; } // Single, Married, etc.
        public string? Religion { get; set; }
        public int StudentId {get; set;}
        public Student Student {get; set;} = null!;
    }
}
