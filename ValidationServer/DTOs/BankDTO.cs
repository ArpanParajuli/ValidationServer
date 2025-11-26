

namespace ValidationServer.DTOs
{
    public class BankDTO
    {
         // ------------ Bank Details ------------
        public string? BankAccountHolderName { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankBranch { get; set; }
    }
}