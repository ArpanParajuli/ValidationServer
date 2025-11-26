using ValidationServer.Models.Students;

namespace ValidationServer.DTOs
{
    public class CreateStudentDTOs
    {
       public  StudentDTO studentDTO { get; set; }
       public  PermanentAddressDTO permanentAddressDTO { get; set; }
       public  TemporaryDTO temporaryDTO { get; set; }
       public  ParentDTO parentDTO { get; set; }
       public  SecondaryInfoDTO secondaryInfoDTO { get; set; }
       public ScholarshipDTO scholarshipDTO { get; set;}
       public EmergencyDTO emergencyDTO { get; set; }
       public EthnicityDTO ethnicityDTO {get; set;}

    }
}