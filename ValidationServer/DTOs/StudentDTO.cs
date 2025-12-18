using System.ComponentModel.DataAnnotations;

namespace ValidationServer.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }


        [Required]
      
        public IFormFile ImagePath { get; set; } = null!;

        [Required]
        [StringLength(50 , MinimumLength =1)]
        public string FirstName { get; set; } = string.Empty;


        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string PlaceOfBirth { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Nationality { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string PrimaryMobile { get; set; } = string.Empty;


        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Gender { get; set; } = string.Empty; 
    }
}