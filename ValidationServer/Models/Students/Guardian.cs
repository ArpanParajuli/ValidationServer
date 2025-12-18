namespace ValidationServer.Models.Students
{
    public class Guardian : BaseEntity
    {
        //public int Id { get; set; } 
        public string? FullName { get; set; }
        public string? Occupation { get; set; }
        public string? MobileNumber { get; set;}
        public string? Email { get; set; }
        public string? Relation {get; set;}
        public string? Organization { get; set; }
        public string? Designation { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
