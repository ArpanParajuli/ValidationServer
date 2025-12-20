using AutoMapper;
using MediatR;
using ValidationServer.Data;
using ValidationServer.Models.Enums;
using ValidationServer.Models.Students;
using ValidationServer.Services;

namespace ValidationServer.Application.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand , bool>
    {

        private readonly AppDbContext _context;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public CreateStudentCommandHandler(AppDbContext context , IImageService imageService, IMapper mapper) 
        { 
             _context = context;
             _imageService = imageService;
             _mapper = mapper;
        }


        public async Task<bool> Handle(CreateStudentCommand command , CancellationToken ct)
        {

            var Dto = command.Dto;

            var student = _mapper.Map<Student>(Dto.StudentDTO);

            if (Dto.StudentDTO.ImagePath != null && Dto.StudentDTO.ImagePath.Length > 0)
            {
                var imageUrl = await _imageService.SaveStudentImageAsync(Dto.StudentDTO.ImagePath);
                student.ImagePath = $"/uploads/students/{imageUrl}";
            }
            else
            {
                student.ImagePath = "/uploads/students/default-avatar.png";
            }


            student.CreatedAt = DateTime.Now;
            student.OwnerId = Guid.NewGuid();

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync(ct);

            using var transaction = await _context.Database.BeginTransactionAsync(ct);


            Console.WriteLine("Create student CreateStudentHandler");

            ////////////// Student Part ///////////////////
            ///
            try
            { 

                ////////////// Addresses Part ///////////////////

                if (Dto.AddressDTO != null && Dto.AddressDTO.Any())
                {
                    if (Dto.AddressDTO.Count == 1)
                    {
                        var addressDto = Dto.AddressDTO.First();

                        var address = _mapper.Map<Address>(addressDto);
                        address.StudentId = student.Id;
                        address.CreatedAt = DateTime.Now;
                        address.CreatedBy = student.OwnerId;
                        address.AddressType = AddressType.Both;

                        await _context.Addresses.AddAsync(address);
                    }

                    else
                    {
                        foreach (var addressDto in Dto.AddressDTO)
                        {
                            var address = _mapper.Map<Address>(addressDto);
                            address.StudentId = student.Id;
                            address.CreatedAt = DateTime.Now;
                            address.CreatedBy = student.OwnerId;
                            address.AddressType = addressDto.IsPermanent == 1
                                ? AddressType.Permanent
                                : AddressType.Temporary;

                            await _context.Addresses.AddAsync(address);
                        }
                    }
                }



                var guardians = new List<Guardian>();

                foreach (var guardian in Dto.GuardianDTO)
                {
                    guardians.Add(new Guardian
                    {
                        StudentId = student.Id,

                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,

                        Designation = guardian.Designation,
                        Email = guardian.Email,
                        FullName = guardian.FullName,
                        MobileNumber = guardian.MobileNumber,
                        Occupation = guardian.Occupation,
                        Organization = guardian.Organization,
                        Relation = guardian.Relation
                    });

                }


                await _context.Guardians.AddRangeAsync(guardians);

                // Handle Secondary Info
                var secondary = _mapper.Map<SecondaryInfo>(Dto.SecondaryInfoDTO);
                secondary.StudentId = student.Id;
                secondary.CreatedAt = DateTime.Now;
                secondary.CreatedBy = student.OwnerId;

                await _context.SecondaryInfos.AddAsync(secondary);

                // Handle Scholarship
                var scholarship = _mapper.Map<Scholarship>(Dto.ScholarshipDTO);
                scholarship.StudentId = student.Id;

                scholarship.CreatedAt = DateTime.Now;
                scholarship.CreatedBy = student.OwnerId;


                scholarship.ScholarshipAmount = Dto.ScholarshipDTO.ScholarshipAmount;
                scholarship.ScholarshipType = Dto.ScholarshipDTO.ScholarshipType;
                scholarship.ScholarshipProviderName = Dto.ScholarshipDTO.ScholarshipProviderName;
                await _context.Scholarships.AddAsync(scholarship);

                // Handle Emergency
                var emergency = _mapper.Map<Emergency>(Dto.EmergencyDTO);
                emergency.StudentId = student.Id;
                emergency.CreatedAt = DateTime.Now;
                emergency.CreatedBy = student.OwnerId;
                await _context.Emergencies.AddAsync(emergency);

                // Handle Ethnicity
                var ethnicity = _mapper.Map<Ethnicity>(Dto.EthnicityDTO);
                ethnicity.StudentId = student.Id;
                ethnicity.CreatedAt = DateTime.Now;
                ethnicity.CreatedBy = student.OwnerId;
                await _context.Ethnicities.AddAsync(ethnicity);


                // Handle Bank Details 

                var bank = _mapper.Map<Bank>(Dto.BankDTO);
                bank.StudentId = student.Id;
                bank.CreatedAt = DateTime.Now;
                bank.CreatedBy = student.OwnerId;
                await _context.Banks.AddAsync(bank);


                var documentList = new List<Document>();


                if (Dto.DocumentsDTO.Signature != null)
                {
                    var sigFile = await _imageService.SaveStudentImageAsync(Dto.DocumentsDTO.Signature);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = sigFile,
                        FilePath = $"/uploads/students/{sigFile}",
                        DocumentType = DocumentType.Signature,
                        ContentType = Dto.DocumentsDTO.Signature.ContentType
                    });

                    Console.WriteLine("Documents made 1!");
                }

                if (Dto.DocumentsDTO.Citizenship != null)
                {
                    var ctznFile = await _imageService.SaveStudentImageAsync(Dto.DocumentsDTO.Citizenship);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = ctznFile,
                        FilePath = $"/uploads/students/{ctznFile}",
                        DocumentType = DocumentType.Citizenship,
                        ContentType = Dto.DocumentsDTO.Citizenship.ContentType

                    });

                    Console.WriteLine("Documents made 2 !");
                }

                if (Dto.DocumentsDTO.CharacterCertificate != null)
                {
                    var ccFile = await _imageService.SaveStudentImageAsync(Dto.DocumentsDTO.CharacterCertificate);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = ccFile,
                        FilePath = $"/uploads/students/{ccFile}",
                        DocumentType = DocumentType.CharacterCertificate,
                        ContentType = Dto.DocumentsDTO.CharacterCertificate.ContentType
                    });

                    Console.WriteLine("Documents made 3 !");
                }


                await _context.Documents.AddRangeAsync(documentList);


                var academic_enrollment = _mapper.Map<AcademicEnrollment>(Dto.AcademicEnrollmentDTO);
                academic_enrollment.StudentId = student.Id;
                academic_enrollment.CreatedAt = DateTime.Now;
                academic_enrollment.CreatedBy = student.OwnerId;
                await _context.AcademicEnrollments.AddAsync(academic_enrollment);




                foreach (var academichistory in Dto.AcademicHistories)
                {
                    var AcademicHistoryData = new AcademicHistory
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        Level = academichistory.Level,
                        BoardUniversity = academichistory.BoardUniversity,
                        InstitutionName = academichistory.InstitutionName,
                        PassedYear = academichistory.PassedYear,
                        DivisionOrGPA = academichistory.DivisionOrGPA
                    };


                    await _context.AcademicHistorys.AddAsync(AcademicHistoryData);




                }



                var citizenshipdata = _mapper.Map<Citizenship>(Dto.CitizenshipDTO);

                if (citizenshipdata != null)
                {
                    citizenshipdata.StudentId = student.Id;
                    citizenshipdata.CreatedAt = DateTime.Now;
                    citizenshipdata.CreatedBy = student.OwnerId;
                    await _context.Citizenships.AddAsync(citizenshipdata);
                }


                var Interests = new List<Interest>();

                foreach (var interest in Dto.InterestDTO)
                {
                    Interests.Add(new Interest
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        Name = interest?.Name,
                        OtherInterest = interest?.OtherInterest
                    });
                }


                await _context.Interests.AddRangeAsync(Interests);






                var OtherInformation = new OtherInformation
                {
                    IsHosteller = Dto.OtherInformationDTO.IsHosteller,
                    TransportationMethod = Dto.OtherInformationDTO.TransportationMethod,
                    StudentId = student.Id,
                    CreatedAt = DateTime.Now,
                    CreatedBy = student.OwnerId
                };


                await _context.OtherInformations.AddAsync(OtherInformation);





                var AwardList = new List<Award>();


                foreach (var award in Dto.AwardDTO)
                {

                    AwardList.Add(new Award
                    {
                        Title = award.Title,
                        IssuingOrganization = award.IssuingOrganization,
                        YearReceived = award.YearReceived,
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId

                    });


                }
                ;





                await _context.Awards.AddRangeAsync(AwardList);





                await _context.SaveChangesAsync(ct);

                await transaction.CommitAsync(ct);


                return true;

            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await transaction.RollbackAsync();
                return false;

            }
        }
    }
}
