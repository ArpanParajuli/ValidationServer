using System.ComponentModel.DataAnnotations;

namespace ValidationServer.DTOs
{
    public class OtherInformationDTO
    {
        [Required]
        public string IsHosteller { get; set; }

        [Required]
     
        public string TransportationMethod { get; set; }
    }
}
