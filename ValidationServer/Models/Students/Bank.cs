using ValidationServer.Models.Students;

namespace ValidationServer.Models.Students
{
    public class Bank
    {
        public int Id { get; set; }
        public string? BankAccountHolderName { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankBranch { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
