namespace ValidationServer.DTOs
{
    public class SecondaryInfoDTO
    {
        public string? MiddleName { get; set; }
        public string? AlternateEmail { get; set; }
        public string? SecondaryMobile { get; set; }
        public string? BloodGroup { get; set; }    // A+, O-, etc.
        public string? MaritalStatus { get; set; } // Single, Married, etc.
        public string? Religion { get; set; }
    }
}