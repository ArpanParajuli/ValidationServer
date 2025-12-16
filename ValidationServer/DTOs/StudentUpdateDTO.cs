namespace ValidationServer.DTOs
{
    public class StudentUpdateDTO
    {
        public StudentReqUpdateDTO StudentDTO { get; set; } = new();
        public List<AddressDTO> AddressDTO { get; set; } = new();
        public GuardianDTO GuardianDTO { get; set; } = new();
        public SecondaryInfoDTO SecondaryInfoDTO { get; set; } = new();
        public CitizenshipDTO CitizenshipDTO { get; set; } = new();
        public ScholarshipDTO ScholarshipDTO { get; set; } = new();
        public EmergencyDTO EmergencyDTO { get; set; } = new();
        public EthnicityDTO EthnicityDTO { get; set; } = new();
        public DocumentsUpdateDTO DocumentsDTO { get; set; } = new();
        public AcademicEnrollmentDTO AcademicEnrollmentDTO { get; set; } = new();
        public List<AcademicHistoryDTO> AcademicHistories { get; set; } = new();
        public BankDTO BankDTO { get; set; } = new();
    }
}
