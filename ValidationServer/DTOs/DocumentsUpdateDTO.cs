namespace ValidationServer.DTOs
{

    /// <summary>
    /// For handiling documents update so making null
    /// </summary>
    public class DocumentsUpdateDTO 
    {
        public IFormFile? CharacterCertificate { get; set; }
        public IFormFile? Signature { get; set; }
        public IFormFile? Citizenship { get; set; }
    }
}
