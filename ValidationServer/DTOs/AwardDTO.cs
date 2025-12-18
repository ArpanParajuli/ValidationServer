using System.ComponentModel.DataAnnotations;

namespace ValidationServer.DTOs
{
    public class AwardDTO
    {
        [Required(ErrorMessage = "Award title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Issuing organization is required")]
        public string IssuingOrganization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date received is required")]
        public DateOnly YearReceived { get; set; }
    }
}
