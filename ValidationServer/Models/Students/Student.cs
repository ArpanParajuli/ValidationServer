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
       
    }
}
