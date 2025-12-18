using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Net;
using System.Xml.Schema;
using ValidationServer.DTOs;
using ValidationServer.DTOs.Response;
using ValidationServer.Models.Enums;
using ValidationServer.Models.Students;
using ValidationServer.Repositories;
using ValidationServer.UOW;

namespace ValidationServer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
     
        private readonly IImageService _imageService;
        public StudentService(IMapper mapper, IUnitOfWork unitOfWork, IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _unitOfWork.StudentRepository.GetAllStudentsFiltered().ToListAsync();
        }

        public async Task<StudentReponseDTO?> GetStudentByIdAsync(Guid id)
        {

            var student = await _unitOfWork.StudentRepository.GetByOwnerId(id);

            if (student == null)
                return null;

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
                AwardDTO  = student.Awards != null ? _mapper.Map<List<AwardDTO>>(student.Awards) : null,
                InterestDTO = student.Interests != null ? _mapper.Map<List<InterestDTO>>(student.Interests) : null,
                OtherInformationDTO = student.OtherInformation != null ? _mapper.Map<OtherInformationDTO>(student.OtherInformation) : null,

            };

            return dto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var student = await _unitOfWork.StudentRepository.GetByOwnerId(id);

            if (student != null)
            {
                //_unitOfWork.Students.Delete(student);
                student.IsDeleted = true;
                await _unitOfWork.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Update(Guid OwnerId, StudentUpdateDTO dto)
        {


            await _unitOfWork.BeginTransactionAsync();


            try
            {

                //var student = await _unitOfWork.StudentRepository.GetById(id);

                var student = await _unitOfWork.StudentRepository.GetByOwnerId(OwnerId);
                if (student == null)
                    return false;




                if (dto.StudentDTO.ImagePath != null && dto.StudentDTO.ImagePath.Length > 0)
                {
                    var imageUrl = await _imageService.SaveStudentImageAsync(dto.StudentDTO.ImagePath);
                    student.ImagePath = $"/uploads/students/{imageUrl}";
                }




                student.DateOfBirth = dto.StudentDTO.DateOfBirth;
                student.PlaceOfBirth = dto.StudentDTO.PlaceOfBirth;
                student.FirstName = dto.StudentDTO.FirstName;
                student.LastName = dto.StudentDTO.LastName;
                student.MiddleName = dto.StudentDTO.MiddleName;

                student.Email = dto.StudentDTO.Email;
                student.PrimaryMobile = dto.StudentDTO.PrimaryMobile;
                student.Gender = dto.StudentDTO.Gender;
                student.UpdatedAt = DateTime.Now;
                student.UpdatedBy = student.OwnerId;







                //_mapper.Map(dto.StudentDTO, student);

                _mapper.Map(dto.BankDTO, student.Bank);

                _mapper.Map(dto.ScholarshipDTO, student.Scholarship);

                _mapper.Map(dto.AcademicEnrollmentDTO, student.AcademicEnrollment);

                _mapper.Map(dto.CitizenshipDTO, student.Citizenship);

                _mapper.Map(dto.SecondaryInfoDTO, student.SecondaryInfo);

                //_mapper.Map(dto.GuardianDTO, student.Guardians);

                _mapper.Map(dto.EmergencyDTO, student.Emergency);

                _mapper.Map(dto.EthnicityDTO, student.Ethnicity);



                foreach (var address in student.Addresses)
                {
                    address.IsDeleted = true;
                }



                //foreach (var address in student.Addresses)
                //{
                //    foreach (var dtoAddress in dto.AddressDTO)
                //    {
                //        if (address.AddressType == AddressType.Permanent && dtoAddress.IsPermanent == 1)
                //        {
                //            _mapper.Map(dtoAddress, address);
                //        }
                //        else if (address.AddressType == AddressType.Temporary && dtoAddress.IsPermanent == 0)
                //        {
                //            _mapper.Map(dtoAddress, address);
                //        }
                //        else if (address.AddressType == AddressType.Both)
                //        {
                //            _mapper.Map(dtoAddress, address);
                //        }
                //    }
                //}


                if (dto.AddressDTO != null)
                {


                    var addressNew = new List<Address>();





                    foreach (var address in dto.AddressDTO)
                    {


                        if (dto.AddressDTO.Count == 1)
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


                        if (dto.AddressDTO.Count == 2)
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


                    await _unitOfWork.Addresses.AddRangeAsync(addressNew);





                }

              




                foreach (var guardian in student.Guardians)
                {
                    guardian.IsDeleted = true;
                }


                var guardians = new List<Guardian>();

                foreach (var guardian in dto.GuardianDTO)
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


                await _unitOfWork.Guardians.AddRangeAsync(guardians);



                if (dto.DocumentsDTO != null)
                {

                    var documentList = new List<Document>();

                    if (dto.DocumentsDTO != null)
                    {
                        foreach (var document in student.Documents)
                        {
                            document.IsDeleted = true;
                        }
                    }



                    if (dto.DocumentsDTO.Signature != null)
                    {
                        var sigFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Signature);

                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = sigFile,
                            FilePath = $"/uploads/students/{sigFile}",
                            DocumentType = DocumentType.Signature,
                            ContentType = dto.DocumentsDTO.Signature.ContentType
                        });

                        Console.WriteLine("Documents made 1!");
                    }

                    if (dto.DocumentsDTO.Citizenship != null)
                    {
                        var ctznFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Citizenship);

                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = ctznFile,
                            FilePath = $"/uploads/students/{ctznFile}",
                            DocumentType = DocumentType.Citizenship,
                            ContentType = dto.DocumentsDTO.Citizenship.ContentType

                        });

                        Console.WriteLine("Documents made 2 !");
                    }

                    if (dto.DocumentsDTO.CharacterCertificate != null)
                    {
                        var ccFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.CharacterCertificate);
                        documentList.Add(new Document
                        {
                            StudentId = student.Id,
                            OwnerId = student.OwnerId,
                            FileName = ccFile,
                            FilePath = $"/uploads/students/{ccFile}",
                            DocumentType = DocumentType.CharacterCertificate,
                            ContentType = dto.DocumentsDTO.CharacterCertificate.ContentType
                        });

                        Console.WriteLine("Documents made 3 !");
                    }

                    await _unitOfWork.Documents.AddRangeAsync(documentList);

                }


               



                if(student.Interests != null)
                {

                    foreach (var interest in student.Interests)
                    {
                        interest.IsDeleted = true;
                    }
                }




                var Interests = new List<Interest>();

                foreach(var interest in dto.InterestDTO)
                {
                    Interests.Add(new Interest
                    {
                        StudentId = student.Id,
                        Name = interest.Name,
                        OtherInterest = interest.OtherInterest
                    });
                }


                await _unitOfWork.Interests.AddRangeAsync(Interests);





                if (dto.OtherInformationDTO != null)
                {
                    student.OtherInformation.TransportationMethod = dto.OtherInformationDTO.TransportationMethod;
                    student.OtherInformation.IsHosteller = dto.OtherInformationDTO.IsHosteller;
                    student.OtherInformation.UpdatedAt = DateTime.Now;
                    student.OtherInformation.UpdatedBy = student.OwnerId;
                }
               




                //var OtherInformation = new OtherInformation
                //{
                //    IsHosteller = dto.OtherInformationDTO.IsHosteller,
                //    TransportationMethod = dto.OtherInformationDTO.TransportationMethod,
                //    StudentId = student.Id
                //};


                //await _unitOfWork.OtherInformations.AddAsync(OtherInformation);


                foreach (var award in student.Awards)
                {
                    award.IsDeleted = true;
                }



                var AwardList = new List<Award>();


                foreach(var award in dto.AwardDTO)
                {

                    AwardList.Add(new Award
                    {
                        Title = award.Title,
                        IssuingOrganization = award.IssuingOrganization,
                        YearReceived = award.YearReceived,
                        StudentId = student.Id

                    });


                };





                await _unitOfWork.Awards.AddRangeAsync(AwardList);




                await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();

                return true;


            }



            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                Console.Write(ex.ToString());
                return false;
            }


}




        public async Task<bool> Create(CreateStudentDTO dto)
        {


            await _unitOfWork.BeginTransactionAsync();
            try
            {   
                var student = _mapper.Map<Student>(dto.StudentDTO);

                if (dto.StudentDTO.ImagePath != null && dto.StudentDTO.ImagePath.Length > 0)
                {
                    var imageUrl = await _imageService.SaveStudentImageAsync(dto.StudentDTO.ImagePath);
                    student.ImagePath = $"/uploads/students/{imageUrl}";
                }
                else
                {
                    student.ImagePath = "/uploads/students/default-avatar.png";
                }


                student.CreatedAt = DateTime.Now;
                student.OwnerId = Guid.NewGuid();
               
                await _unitOfWork.Students.AddAsync(student);
                await _unitOfWork.SaveAsync();



                if (dto.AddressDTO != null && dto.AddressDTO.Any())
                {
                    if (dto.AddressDTO.Count == 1)
                    {
                        var addressDto = dto.AddressDTO.First();

                        var address = _mapper.Map<Address>(addressDto);
                        address.StudentId = student.Id;
                        address.CreatedAt = DateTime.Now;
                        address.CreatedBy = student.OwnerId;
                        address.AddressType = AddressType.Both;

                        await _unitOfWork.Addresses.AddAsync(address);
                    }
                    
                    else
                    {
                        foreach (var addressDto in dto.AddressDTO)
                        {
                            var address = _mapper.Map<Address>(addressDto);
                            address.StudentId = student.Id;
                            address.CreatedAt = DateTime.Now;
                            address.CreatedBy = student.OwnerId;
                            address.AddressType = addressDto.IsPermanent == 1
                                ? AddressType.Permanent
                                : AddressType.Temporary;

                            await _unitOfWork.Addresses.AddAsync(address);
                        }
                    }
                }


                var guardians = new List<Guardian>();

                foreach (var guardian in dto.GuardianDTO)
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


                await _unitOfWork.Guardians.AddRangeAsync(guardians);

                // Handle Secondary Info
                var secondary = _mapper.Map<SecondaryInfo>(dto.SecondaryInfoDTO);
                secondary.StudentId = student.Id;
                secondary.CreatedAt = DateTime.Now;
                secondary.CreatedBy = student.OwnerId;

                await _unitOfWork.SecondaryInfo.AddAsync(secondary);

                // Handle Scholarship
                var scholarship = _mapper.Map<Scholarship>(dto.ScholarshipDTO);
                scholarship.StudentId = student.Id;

                scholarship.CreatedAt = DateTime.Now;
                scholarship.CreatedBy = student.OwnerId;


                scholarship.ScholarshipAmount = dto.ScholarshipDTO.ScholarshipAmount;
                scholarship.ScholarshipType = dto.ScholarshipDTO.ScholarshipType;
                scholarship.ScholarshipProviderName = dto.ScholarshipDTO.ScholarshipProviderName;
                await _unitOfWork.Scholarships.AddAsync(scholarship);

                // Handle Emergency
                var emergency = _mapper.Map<Emergency>(dto.EmergencyDTO);
                emergency.StudentId = student.Id;
                emergency.CreatedAt = DateTime.Now;
                emergency.CreatedBy = student.OwnerId;
                await _unitOfWork.Emergency.AddAsync(emergency);

                // Handle Ethnicity
                var ethnicity = _mapper.Map<Ethnicity>(dto.EthnicityDTO);
                ethnicity.StudentId = student.Id;
                ethnicity.CreatedAt = DateTime.Now;
                ethnicity.CreatedBy = student.OwnerId;
                await _unitOfWork.Ethinicities.AddAsync(ethnicity);


                // Handle Bank Details 

                var bank = _mapper.Map<Bank>(dto.BankDTO);
                bank.StudentId = student.Id;
                bank.CreatedAt = DateTime.Now;
                bank.CreatedBy = student.OwnerId;
                await _unitOfWork.Banks.AddAsync(bank);


                var documentList = new List<Document>();


                if (dto.DocumentsDTO.Signature != null)
                {
                    var sigFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Signature);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = sigFile,
                        FilePath = $"/uploads/students/{sigFile}",
                        DocumentType = DocumentType.Signature,
                        ContentType = dto.DocumentsDTO.Signature.ContentType
                    });

                    Console.WriteLine("Documents made 1!");
                }

                if (dto.DocumentsDTO.Citizenship != null)
                {
                    var ctznFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Citizenship);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = ctznFile,
                        FilePath = $"/uploads/students/{ctznFile}",
                        DocumentType = DocumentType.Citizenship,
                        ContentType = dto.DocumentsDTO.Citizenship.ContentType

                    });

                    Console.WriteLine("Documents made 2 !");
                }

                if (dto.DocumentsDTO.CharacterCertificate != null)
                {
                    var ccFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.CharacterCertificate);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
                        CreatedAt = DateTime.Now,
                        CreatedBy = student.OwnerId,
                        FileName = ccFile,
                        FilePath = $"/uploads/students/{ccFile}",
                        DocumentType = DocumentType.CharacterCertificate,
                        ContentType = dto.DocumentsDTO.CharacterCertificate.ContentType
                    });

                    Console.WriteLine("Documents made 3 !");
                }

             
                await _unitOfWork.Documents.AddRangeAsync(documentList);


                var academic_enrollment = _mapper.Map<AcademicEnrollment>(dto.AcademicEnrollmentDTO);
                academic_enrollment.StudentId = student.Id;
                academic_enrollment.CreatedAt = DateTime.Now;
                academic_enrollment.CreatedBy = student.OwnerId;
                await _unitOfWork.AcademicEnrollments.AddAsync(academic_enrollment);

            


                foreach (var academichistory in dto.AcademicHistories)
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


                    await _unitOfWork.AcademicHistorys.AddAsync(AcademicHistoryData); 



            
                }



                var citizenshipdata = _mapper.Map<Citizenship>(dto.CitizenshipDTO);

                if(citizenshipdata != null)
                {
                    citizenshipdata.StudentId = student.Id;
                    citizenshipdata.CreatedAt = DateTime.Now;
                    citizenshipdata.CreatedBy = student.OwnerId;
                    await _unitOfWork.Citizenships.AddAsync(citizenshipdata);
                }


                var Interests = new List<Interest>();

                foreach (var interest in dto.InterestDTO)
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


                await _unitOfWork.Interests.AddRangeAsync(Interests);






                var OtherInformation = new OtherInformation
                {
                    IsHosteller = dto.OtherInformationDTO.IsHosteller,
                    TransportationMethod = dto.OtherInformationDTO.TransportationMethod,
                    StudentId = student.Id,
                    CreatedAt = DateTime.Now,
                    CreatedBy = student.OwnerId
                };


                await _unitOfWork.OtherInformations.AddAsync(OtherInformation);





                var AwardList = new List<Award>();


                foreach (var award in dto.AwardDTO)
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





                await _unitOfWork.Awards.AddRangeAsync(AwardList);





                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();

                return true;
                 
            }
            catch (Exception ex)
            {
 
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                await _unitOfWork.RollbackTransactionAsync();

                return false;
            }
        }

    }
}
