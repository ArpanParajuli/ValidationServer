
namespace ValidationServer.Models.Students
{
    public class PermanentAddress
    {
        // ------------ Permanent Address (Required) ------------
        public int Id { get; set; }
        public bool isTemporarySame {get ; set;} = false;
        public string PermanentProvince { get; set; } = string.Empty;
        public string PermanentDistrict { get; set; } = string.Empty;
        public string PermanentMunicipality { get; set; } = string.Empty;
        public string PermanentWardNumber { get; set; } = string.Empty;
        public string PermanentToleStreet { get; set; } = string.Empty;
        public string? PermanentHouseNumber { get; set; }

        public int StudentId { get; set; }  
        public Student Student { get; set; }   
    }
}
