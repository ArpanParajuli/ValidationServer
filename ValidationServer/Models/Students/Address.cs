using ValidationServer.Models.Enums;

namespace ValidationServer.Models.Students
{
    public class Address : BaseEntity
    {
        //public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string WardNumber { get; set; } = string.Empty;
        public string ToleStreet { get; set; } = string.Empty;
        public string? HouseNumber { get; set; }
        public AddressType AddressType { get; set; }
        public int StudentId { get; set; }  
        public Student? Student { get; set; }   
    }
}
