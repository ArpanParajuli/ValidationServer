namespace ValidationServer.Models.Students
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nepali";
        public int StudentId { get; set; }
        public Student? Student { get; set;}
    }
}
