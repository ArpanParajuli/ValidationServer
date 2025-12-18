using System.ComponentModel.DataAnnotations;

namespace ValidationServer.Models.Students
{
    public class Award : BaseEntity
    {
        //public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string IssuingOrganization { get; set; } = string.Empty;

        [Required]
        public DateOnly YearReceived { get; set; }
    }
}
