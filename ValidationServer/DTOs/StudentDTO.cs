namespace ValidationServer.DTOs
{
    public class StudentDTO
    {
        public string ImagePath { get; set; } = string.Empty;   // store image URL or path
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }    // City/District
        public string Nationality { get; set; } = "Nepali";
        public string CitizenshipNumber { get; set; } = string.Empty;
        public DateOnly CitizenshipIssueDate { get; set; }
        public string CitizenshipIssueDistrict { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PrimaryMobile { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty; // Male/Female/Other
    }
}