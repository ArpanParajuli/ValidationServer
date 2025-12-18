namespace ValidationServer.Models.Students
{
    public class Fee : BaseEntity
    {
        //public int Id { get; set; }
        public string FeeCategory { get; set; } = "Regular"; // Options: Regular, Self-Financed, Scholarship, Quota
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
