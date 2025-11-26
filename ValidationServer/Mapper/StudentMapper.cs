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
            CreateMap<PermanentAddressDTO, PermanentAddress>();
            CreateMap<TemporaryDTO, TemporaryAddress>();
            CreateMap<ParentDTO, Parent>();
            CreateMap<ScholarshipDTO, Scholarship>();
            CreateMap<EmergencyDTO, Emergency>();
            CreateMap<EthnicityDTO, Ethnicity>();
            CreateMap<SecondaryInfoDTO, SecondaryInfo>();
        }
    }
}
