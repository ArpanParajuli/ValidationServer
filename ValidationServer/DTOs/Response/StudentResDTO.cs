namespace ValidationServer.DTOs.Response
{
    public class StudentResDTO
    {
        //public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string Nationality { get; set; } = "Nepali";
        public string Email { get; set; } = string.Empty;
        public string PrimaryMobile { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
