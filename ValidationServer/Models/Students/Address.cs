using ValidationServer.Models.Students;

namespace ValidationServer.Models.Students
{
    public class Address
    {
        public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string WardNumber { get; set; } = string.Empty;
        public string ToleStreet { get; set; } = string.Empty;
        public string? HouseNumber { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Permanent;
        public int StudentId { get; set; }  
        public Student? Student { get; set; }   
    }
}
