using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValidationServer.Models.Students
{
    public class OtherInformation
    {
            public int Id { get; set; }

            public int StudentId { get; set; }
            public  Student Student { get; set; }

            [Required]

            public string IsHosteller { get; set; }

            [Required]
    
            public string TransportationMethod { get; set; }
        }

      
}
