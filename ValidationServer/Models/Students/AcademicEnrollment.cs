using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Enums;

namespace ValidationServer.Models.Students
{
    public class AcademicEnrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        [Required]
        public string Faculty { get; set; } = string.Empty;

        [Required]
        public string Program { get; set; } = string.Empty;

        [Required]
        public Level Level { get; set; }

        [Required]
        public string Semester { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        [Required]
        public string RollNumber { get; set; } = string.Empty;
        [Required]
        public string RegistrationNumber { get; set; } = string.Empty;


        [Required]
        public DateOnly EnrollDate { get; set; }

        [Required]
        public AcademicStatus AcademicStatus { get; set; } = AcademicStatus.Active;

    }


}