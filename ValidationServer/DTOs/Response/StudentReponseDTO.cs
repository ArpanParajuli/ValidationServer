using System.ComponentModel.DataAnnotations;
using ValidationServer.DTOs;

namespace ValidationServer.DTOs.Response
{
    public class StudentReponseDTO
    {
        public StudentResDTO? StudentDTO { get; set; }
        public List<AddressDTO> AddressDTO { get; set; } = new();
        public List<GuardianDTO> GuardianDTO { get; set; } = new();
        public SecondaryInfoDTO SecondaryInfoDTO { get; set; } = new();
        public CitizenshipDTO CitizenshipDTO { get; set; } = new();
        public ScholarshipDTO ScholarshipDTO { get; set; } = new();
        public EmergencyDTO EmergencyDTO { get; set; } = new();
        public EthnicityDTO EthnicityDTO { get; set; } = new();
        public DocumentsDTO DocumentsDTO { get; set; } = new();
        public AcademicEnrollmentDTO AcademicEnrollmentDTO { get; set; } = new();
        public List<AcademicHistoryDTO> AcademicHistories { get; set; } = new();
        public BankDTO BankDTO { get; set; } = new();
        public List<AwardDTO> AwardDTO { get; set; } = new();

        public List<InterestDTO> InterestDTO { get; set; } = new();

        public OtherInformationDTO OtherInformationDTO { get; set; } = new();

    }
}
