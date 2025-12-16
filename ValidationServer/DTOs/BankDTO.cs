

using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Students;

namespace ValidationServer.DTOs
{
    public class BankDTO
    {

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string BankAccountHolderName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string BankName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string BankBranch { get; set; } = string.Empty;

    }
}