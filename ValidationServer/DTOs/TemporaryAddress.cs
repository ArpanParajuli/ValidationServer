namespace ValidationServer.DTOs
{
    public class TemporaryAddress
    {
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string WardNumber { get; set; } = string.Empty;
        public string ToleStreet { get; set; } = string.Empty;
        public string? HouseNumber { get; set; }
    }
}
