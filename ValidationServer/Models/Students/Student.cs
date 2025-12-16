namespace ValidationServer.Models.Students
{
    public class Student
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }    
        public string Email { get; set; } = string.Empty;
        public string PrimaryMobile { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;


        
        public Citizenship? Citizenship { get; set; }
        public Guardian? Guardian { get; set; }
        public Scholarship? Scholarship { get; set; }
        public Emergency? Emergency { get; set; }
        public SecondaryInfo? SecondaryInfo { get; set; }

        public Ethnicity Ethnicity { get; set; } = null!;


        public AcademicEnrollment? AcademicEnrollment { get; set; }

        public Bank? Bank { get; set; }


        public ICollection<Address>? Addresses { get; set; }
        
        public ICollection<AcademicHistory>? AcademicHistories { get; set; }
        public ICollection<Document>? Documents { get; set; }

    }
}
