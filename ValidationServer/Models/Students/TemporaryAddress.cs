using ValidationServer.Models.Students;

namespace ValidationServer.Models.Students
{
    public class TemporaryAddress
    {
        // ------------ Temporary Address (Optional) ------------
        public int Id { get; set; }
        public string? TemporaryProvince { get; set; }
        public string? TemporaryDistrict { get; set; }
        public string? TemporaryMunicipality { get; set; }
        public string? TemporaryWardNumber { get; set; }
        public string? TemporaryToleStreet { get; set; }
        public string? TemporaryHouseNumber { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
