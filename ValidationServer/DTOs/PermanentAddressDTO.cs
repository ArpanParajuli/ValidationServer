namespace ValidationServer.DTOs
{
    public class PermanentAddressDTO
    {
        public bool isTemporarySame {get ; set;}
        public string PermanentProvince { get; set; } = string.Empty;
        public string PermanentDistrict { get; set; } = string.Empty;
        public string PermanentMunicipality { get; set; } = string.Empty;
        public string PermanentWardNumber { get; set; } = string.Empty;
        public string PermanentToleStreet { get; set; } = string.Empty;
        public string? PermanentHouseNumber { get; set; }
    }
}