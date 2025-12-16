using AutoMapper;
using ValidationServer.DTOs;
using ValidationServer.DTOs.Response;
using ValidationServer.Models;
using ValidationServer.Models.Students;

namespace ValidationServer.Mapper
{
    public class StudentMapper : Profile 
    {
        public StudentMapper()
        {
            // Student
            CreateMap<StudentDTO, Student>().ReverseMap();
      

            CreateMap<StudentResDTO, Student>().ReverseMap();



            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentReponseDTO, Student>().ReverseMap();

            // Address
            CreateMap<AddressDTO, Address>().ReverseMap();

            // Citizenship
            CreateMap<CitizenshipDTO, Citizenship>().ReverseMap();

            // Guardian
            CreateMap<GuardianDTO, Guardian>().ReverseMap();

            // Scholarship
            CreateMap<ScholarshipDTO, Scholarship>().ReverseMap();

            // Emergency Contact
            CreateMap<EmergencyDTO, Emergency>().ReverseMap();

            // Ethnicity
            CreateMap<EthnicityDTO, Ethnicity>().ReverseMap();

            // Secondary Info
            CreateMap<SecondaryInfoDTO, SecondaryInfo>().ReverseMap();

            // Documents
            CreateMap<DocumentsDTO, Document>().ReverseMap();

            // Academic Enrollment
            CreateMap<AcademicEnrollmentDTO, AcademicEnrollment>().ReverseMap();

            // Academic History (fixed mapping!)
            CreateMap<AcademicHistoryDTO, AcademicHistory>().ReverseMap();


            CreateMap<BankDTO, Bank>().ReverseMap();

        }
    }
}
