using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Enums;

namespace ValidationServer.Models.Students
{
    public class AcademicHistory
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public Level? Level { get; set; }

        [Required]
        public string BoardUniversity { get; set; }

        [Required]
        public string InstitutionName { get; set; }

        [Required]
        public DateOnly PassedYear { get; set; }

        public string DivisionOrGPA { get; set; }
    }
}
