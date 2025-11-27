using AutoMapper;
using ValidationServer.DTOs;
using ValidationServer.Models;
using ValidationServer.Models.Students;

namespace ValidationServer.Mapper
{
    public class StudentMapper : Profile 
    {
        public StudentMapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<AddressDTO, Address>();
            CreateMap<CitizenshipDTO, Citizenship>();
            CreateMap<GuardianDTO, Guardian>();
            CreateMap<ScholarshipDTO, Scholarship>();
            CreateMap<EmergencyDTO, Emergency>();
            CreateMap<EthnicityDTO, Ethnicity>();
            CreateMap<SecondaryInfoDTO, SecondaryInfo>();
        }
    }
}
