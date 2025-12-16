using System.ComponentModel.DataAnnotations;

namespace ValidationServer.DTOs
{
    public class DocumentsDTO
    {
       // [Required] 
        public IFormFile? CharacterCertificate { get; set; }
       // [Required]
        public IFormFile? Signature { get; set; }
        //[Required]
        public IFormFile? Citizenship { get; set; }
    }
}
