namespace ValidationServer.Models.Students
{
    public class Interest : BaseEntity
    {
        //public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? OtherInterest { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

    }
}
