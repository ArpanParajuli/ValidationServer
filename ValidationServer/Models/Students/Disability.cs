namespace ValidationServer.Models.Students
{
    public class Disability : BaseEntity
    {
        //public int Id { get; set; }
        public string DisabilityStatus { get; set; } = "None";
        public string? DisabilityType { get; set; } // Only if not None
        public int? DisabilityPercentage { get; set; } // 0–100
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

