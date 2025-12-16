using System.ComponentModel.DataAnnotations;

namespace ValidationServer.DTOs
{
    public class AddressDTO
    {
        public int IsPermanent { get ; set;}

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Province { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string District { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Municipality { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string WardNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string ToleStreet { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string HouseNumber { get; set; } = string.Empty;
    }
}