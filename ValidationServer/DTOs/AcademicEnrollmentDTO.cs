using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Enums;

namespace ValidationServer.DTOs
{
    public class AcademicEnrollmentDTO
    {
        [Required]
        public string Faculty { get; set; }  
        [Required]
        public string Program { get; set; } 
        [Required]
        public Level Level { get; set; } 
        [Required]
        public string Semester { get; set; }
        public string Section { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public DateTime EnrollDate { get; set; }

        [Required]
        public int AcademicStatus { get; set; }
    }

}
