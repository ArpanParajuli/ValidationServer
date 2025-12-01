using System.Net.Http.Headers;
using ValidationServer.Models.Students;

namespace ValidationServer.DTOs
{
    public class CreateStudentDTO
    {
       public  StudentDTO StudentDTO { get; set; } = new();
       public  AddressDTO AddressDTO { get; set; } = new();
       public  GuardianDTO GuardianDTO { get; set; } = new();
       public  SecondaryInfoDTO SecondaryInfoDTO { get; set; } = new();
       public CitizenshipDTO CitizenshipDTO{get; set;} = new();
       public ScholarshipDTO ScholarshipDTO { get; set;} = new();
       public EmergencyDTO EmergencyDTO { get; set; } = new();
       public EthnicityDTO EthnicityDTO {get; set;} = new();
       public DocumentsDto DocumentsDTO { get; set; } = new();
       public AcademicEnrollmentDTO AcademicEnrollmentDTO { get; set; } = new();
       public List<AcademicHistoryDTO> AcademicHistories { get; set; } = new();


    }
}