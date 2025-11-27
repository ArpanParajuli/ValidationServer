namespace ValidationServer.DTOs
{
    public class AddressDTO
    {
        public bool isTemporarySame {get ; set;}
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string WardNumber { get; set; } = string.Empty;
        public string ToleStreet { get; set; } = string.Empty;
        public string? HouseNumber { get; set; }
    }
}