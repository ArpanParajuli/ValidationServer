namespace ValidationServer.DTOs
{
    public class ScholarshipDTO
    {
        public string? ScholarshipType { get; set; }         // Government, Institutional, Private
        public string? ScholarshipProviderName { get; set; }
        public decimal? ScholarshipAmount { get; set; }
    }
}
