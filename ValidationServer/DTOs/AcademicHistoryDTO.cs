using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Enums;

namespace ValidationServer.DTOs
{
    public class AcademicHistoryDTO
    {
      //  [Required]
        public int Level { get; set;}

      //  [Required]
        public string BoardUniversity { get; set; }

     //   [Required]
        public string InstitutionName { get; set; }

       // [Required]
        public DateOnly PassedYear { get; set; }

        public string DivisionOrGPA { get; set; }

    }
}
