using System.ComponentModel.DataAnnotations;
using ValidationServer.DTOs;

namespace ValidationServer.DTOs.Response
{
    public class StudentReponseDTO
    {
        public StudentResDTO? StudentDTO { get; set; }
        public List<AddressDTO>? AddressDTO { get; set; }
        public GuardianDTO? GuardianDTO { get; set; }
        public SecondaryInfoDTO? SecondaryInfoDTO { get; set; }
        public CitizenshipDTO? CitizenshipDTO { get; set; } 
        public ScholarshipDTO? ScholarshipDTO { get; set; } 
        public EmergencyDTO? EmergencyDTO { get; set; } 
        public EthnicityDTO? EthnicityDTO { get; set; } 
        public DocumentsDTO? DocumentsDTO { get; set; } 
        public AcademicEnrollmentDTO? AcademicEnrollmentDTO { get; set; } 
        public List<AcademicHistoryDTO>? AcademicHistories { get; set; }
    

        public BankDTO? BankDTO { get; set; } 
    }
}
