namespace ValidationServer.Models.Students
{
    public class Financial : BaseEntity
    {
        //public int Id { get; set; }
        public string AnnualFamilyIncome { get; set; } = "<5 Lakh";
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
