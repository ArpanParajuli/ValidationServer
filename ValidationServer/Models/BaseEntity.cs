using System.ComponentModel.DataAnnotations;

namespace ValidationServer.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set;}
        public Guid? DeletedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

    }
}
