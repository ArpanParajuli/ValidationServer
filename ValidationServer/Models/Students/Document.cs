using System.ComponentModel.DataAnnotations;
using ValidationServer.Models.Enums;

namespace ValidationServer.Models.Students
{
    public class Document
    {
        public int Id { get; set;}

        public int StudentId { get; set;}
        public Student Student { get; set; }
        public DocumentType DocumentType { get; set; } // enum set gareko 

        [Required]
        [MaxLength(500)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(2000)]
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string ContentType { get; set; }
    }
}
