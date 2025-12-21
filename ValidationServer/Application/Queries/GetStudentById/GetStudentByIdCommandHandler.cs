using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ValidationServer.Data;
using ValidationServer.DTOs;
using ValidationServer.DTOs.Response;
using ValidationServer.Models.Students;
using MediatR;
using ValidationServer.Models.Enums;


namespace ValidationServer.Application.Queries.GetStudentById
{
    public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdCommand , StudentReponseDTO?>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentByIdCommandHandler(AppDbContext context , IMapper mapper) { _context = context; _mapper = mapper; }

        public async Task<StudentReponseDTO?> Handle(GetStudentByIdCommand command , CancellationToken ct)
        {
               var student = await _context.Students.AsNoTracking()

                  .Include(s => s.Addresses.Where(a => !a.IsDeleted))
                  .Include(s => s.Guardians.Where(g => !g.IsDeleted))
                  .Include(s => s.AcademicHistories.Where(h => !h.IsDeleted))
                  .Include(s => s.Awards.Where(a => !a.IsDeleted))
                  .Include(s => s.Interests.Where(i => !i.IsDeleted))
                  .Include(s => s.Documents.Where(d => !d.IsDeleted))


                  .Include(s => s.SecondaryInfo)
                  .Include(s => s.Citizenship)
                  .Include(s => s.Scholarship)
                  .Include(s => s.Emergency)
                  .Include(s => s.Ethnicity)
                  .Include(s => s.AcademicEnrollment)
                  .Include(s => s.Bank)
                  .Include(s => s.OtherInformation)

                  .FirstOrDefaultAsync(s => s.OwnerId == command.Id && !s.IsDeleted , ct);

            if (student == null)
                return null;


            var documentsDto = new DocumentResDTO();

            if(student.Documents != null)
            {
                foreach(var document in student.Documents)
                {
                    if(document.DocumentType == DocumentType.CharacterCertificate)
                    {
                        documentsDto.CharacterCertificate = document.FilePath;
                    }

                    if(document.DocumentType == DocumentType.Citizenship)
                    {
                        documentsDto.Citizenship = document.FilePath;
                    }

                    if (document.DocumentType == DocumentType.Signature)
                    {
                        documentsDto.Signature = document.FilePath;
                    }

                }
            }
            

            var dto = new StudentReponseDTO
            {
                StudentDTO = _mapper.Map<StudentResDTO>(student),
                AddressDTO = student.Addresses != null ? _mapper.Map<List<AddressDTO>>(student.Addresses) : null,
                GuardianDTO = student.Guardians != null ? _mapper.Map<List<GuardianDTO>>(student.Guardians) : null,
                SecondaryInfoDTO = student.SecondaryInfo != null ? _mapper.Map<SecondaryInfoDTO>(student.SecondaryInfo) : null,
                CitizenshipDTO = student.Citizenship != null ? _mapper.Map<CitizenshipDTO>(student.Citizenship) : null,
                ScholarshipDTO = student.Scholarship != null ? _mapper.Map<ScholarshipDTO>(student.Scholarship) : null,
                EmergencyDTO = student.Emergency != null ? _mapper.Map<EmergencyDTO>(student.Emergency) : null,
                EthnicityDTO = student.Ethnicity != null ? _mapper.Map<EthnicityDTO>(student.Ethnicity) : null,
                AcademicEnrollmentDTO = student.AcademicEnrollment != null ? _mapper.Map<AcademicEnrollmentDTO>(student.AcademicEnrollment) : null,
                AcademicHistories = student.AcademicHistories != null ? _mapper.Map<List<AcademicHistoryDTO>>(student.AcademicHistories) : null,
                BankDTO = student.Bank != null ? _mapper.Map<BankDTO>(student.Bank) : null,
                AwardDTO = student.Awards != null ? _mapper.Map<List<AwardDTO>>(student.Awards) : null,
                InterestDTO = student.Interests != null ? _mapper.Map<List<InterestDTO>>(student.Interests) : null,
                OtherInformationDTO = student.OtherInformation != null ? _mapper.Map<OtherInformationDTO>(student.OtherInformation) : null,
                DocumentsDTO = documentsDto

            }; 

            return dto;
        }
    }
}
