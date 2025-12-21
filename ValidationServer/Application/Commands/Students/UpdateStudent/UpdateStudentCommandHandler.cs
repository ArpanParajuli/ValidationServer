using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationServer.Data;
using ValidationServer.Models.Enums;
using ValidationServer.Models.Students;
using ValidationServer.Services;

namespace ValidationServer.Application.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        private readonly IImageService _imageservice;

        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(AppDbContext context, IImageService imageservice, IMapper mapper)
        {

            _context = context;
            _imageservice = imageservice;
            _mapper = mapper;
        }


        public async Task<bool> Handle(UpdateStudentCommand command, CancellationToken ct)
        {
            Console.WriteLine("Update student command handler!");

            var student = await _context.Students
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

                  .FirstOrDefaultAsync(s => s.OwnerId == command.Id && !s.IsDeleted);

            if (student == null)
                return false;

            var Dto = command.request;

            if (Dto == null) return false;


            using var transaction = await _context.Database.BeginTransactionAsync(ct);

            try
            {

                if (Dto.StudentDTO.ImagePath != null && Dto.StudentDTO.ImagePath.Length > 0)
                {
                    var imageUrl = await _imageservice.SaveStudentImageAsync(Dto.StudentDTO.ImagePath);
                    student.ImagePath = $"/uploads/students/{imageUrl}";
                }

                student.DateOfBirth = Dto.StudentDTO.DateOfBirth;
                student.PlaceOfBirth = Dto.StudentDTO.PlaceOfBirth;
                student.FirstName = Dto.StudentDTO.FirstName;
                student.LastName = Dto.StudentDTO.LastName;
                student.MiddleName = Dto.StudentDTO.MiddleName;

                student.Email = Dto.StudentDTO.Email;
                student.PrimaryMobile = Dto.StudentDTO.PrimaryMobile;
                student.Gender = Dto.StudentDTO.Gender;
                student.UpdatedAt = DateTime.Now;
                student.UpdatedBy = student.OwnerId;


                _mapper.Map(Dto.BankDTO, student.Bank);

                _mapper.Map(Dto.ScholarshipDTO, student.Scholarship);

                _mapper.Map(Dto.AcademicEnrollmentDTO, student.AcademicEnrollment);

                _mapper.Map(Dto.CitizenshipDTO, student.Citizenship);

                _mapper.Map(Dto.SecondaryInfoDTO, student.SecondaryInfo);

                _mapper.Map(Dto.EmergencyDTO, student.Emergency);

                _mapper.Map(Dto.EthnicityDTO, student.Ethnicity);


                if(student.Addresses != null)
                {
                    foreach (var address in student.Addresses)
                    {
                        address.IsDeleted = true;
                    }
                }
                



                if (Dto.AddressDTO != null)
                {
                    var addressNew = new List<Address>();

                    foreach (var address in Dto.AddressDTO)
                    {


                        if (Dto.AddressDTO.Count == 1)
                        {
                            addressNew.Add(new Address
                            {
                                StudentId = student.Id,
                                OwnerId = student.OwnerId,
                                AddressType = AddressType.Both,
                                CreatedAt = DateTime.Now,
                                CreatedBy = student.OwnerId,
                                Province = address.Province,
                                District = address.District,
                                Municipality = address.Municipality,
                                WardNumber = address.WardNumber,
                                ToleStreet = address.ToleStreet,
                                HouseNumber = address.HouseNumber
                            });
                        }


                        else
                        {
                            addressNew.Add(new Address
                            {
                                StudentId = student.Id,
                                OwnerId = student.OwnerId,
                                AddressType = (address.IsPermanent == 1) ? AddressType.Permanent : AddressType.Temporary,
                                CreatedAt = DateTime.Now,
                                CreatedBy = student.OwnerId,
                                Province = address.Province,
                                District = address.District,
                                Municipality = address.Municipality,
                                WardNumber = address.WardNumber,
                                ToleStreet = address.ToleStreet,
                                HouseNumber = address.HouseNumber
                            });
                        }


                    }

                    await _context.Addresses.AddRangeAsync(addressNew);

                }


                if(student.AcademicHistories != null)
                {
                    foreach(var academichistory in student.AcademicHistories)
                    {
                        academichistory.IsDeleted = true;
                    }
                }

                var AcademicHistoryData = new List<AcademicHistory>();

                foreach (var academichistory in Dto.AcademicHistories)
                {
                    AcademicHistoryData.Add( new AcademicHistory
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        Level = academichistory.Level,
                        BoardUniversity = academichistory.BoardUniversity,
                        InstitutionName = academichistory.InstitutionName,
                        PassedYear = academichistory.PassedYear,
                        DivisionOrGPA = academichistory.DivisionOrGPA
                    });


                }

                await _context.AcademicHistorys.AddRangeAsync(AcademicHistoryData);

                




                foreach (var guardian in student.Guardians)
                {
                    guardian.IsDeleted = true;
                }


                var guardians = new List<Guardian>();

                foreach (var guardian in Dto.GuardianDTO)
                {
                    guardians.Add(new Guardian
                    {
                        StudentId = student.Id,
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



                if (Dto.DocumentsDTO != null)
                {

                    var documentList = new List<Document>();

                    if (Dto.DocumentsDTO != null)
                    {
                        if(student.Documents != null)
                        {
                            foreach (var document in student.Documents)
                            {
                                document.IsDeleted = true;
                            }
                        }
                       
                    }

                    if (Dto.DocumentsDTO?.Signature != null)
                    {
                        var sigFile = await _imageservice.SaveStudentImageAsync(Dto.DocumentsDTO.Signature);

                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = sigFile,
                            FilePath = $"/uploads/students/{sigFile}",
                            DocumentType = DocumentType.Signature,
                            ContentType = Dto.DocumentsDTO.Signature.ContentType
                        });

                        Console.WriteLine("Documents made 1!");
                    }

                    if (Dto.DocumentsDTO?.Citizenship != null)
                    {
                        var ctznFile = await _imageservice.SaveStudentImageAsync(Dto.DocumentsDTO.Citizenship);

                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = ctznFile,
                            FilePath = $"/uploads/students/{ctznFile}",
                            DocumentType = DocumentType.Citizenship,
                            ContentType = Dto.DocumentsDTO.Citizenship.ContentType

                        });

                        Console.WriteLine("Documents made 2 !");
                    }

                    if (Dto.DocumentsDTO?.CharacterCertificate != null)
                    {
                        var ccFile = await _imageservice.SaveStudentImageAsync(Dto.DocumentsDTO.CharacterCertificate);
                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = ccFile,
                            FilePath = $"/uploads/students/{ccFile}",
                            DocumentType = DocumentType.CharacterCertificate,
                            ContentType = Dto.DocumentsDTO.CharacterCertificate.ContentType
                        });

                        Console.WriteLine("Documents made 3 !");
                    }

                    await _context.Documents.AddRangeAsync(documentList);

                }






                if (student.Interests != null)
                {

                    foreach (var interest in student.Interests)
                    {
                        interest.IsDeleted = true;
                    }
                }






                var Interests = new List<Interest>();

                foreach (var interest in Dto.InterestDTO)
                {
                    Interests.Add(new Interest
                    {
                        StudentId = student.Id,
                        Name = interest.Name,
                        OtherInterest = interest.OtherInterest
                    });
                }


                await _context.Interests.AddRangeAsync(Interests);


                if (Dto.OtherInformationDTO != null && student.OtherInformation != null)
                {
                    student.OtherInformation.TransportationMethod =
                        Dto.OtherInformationDTO.TransportationMethod;

                    student.OtherInformation.IsHosteller =
                        Dto.OtherInformationDTO.IsHosteller;

                    student.OtherInformation.UpdatedAt = DateTime.Now;
                    student.OtherInformation.UpdatedBy = student.OwnerId;
                }




                foreach (var award in student.Awards)
                {
                    award.IsDeleted = true;
                }



                var AwardList = new List<Award>();


                foreach (var award in Dto.AwardDTO)
                {

                    AwardList.Add(new Award
                    {
                        Title = award.Title,
                        IssuingOrganization = award.IssuingOrganization,
                        YearReceived = award.YearReceived,
                        StudentId = student.Id

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
                Console.WriteLine(ex.ToString());
                await transaction.RollbackAsync();
                return false;
            }


    }
    }

}
