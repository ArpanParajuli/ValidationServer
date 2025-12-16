using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using ValidationServer.DTOs;
using ValidationServer.DTOs.Response;
using ValidationServer.Models.Enums;
using ValidationServer.Models.Students;
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
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<StudentReponseDTO?> GetStudentByIdAsync(int id)
        {

            var student = await _unitOfWork.StudentRepository.GetById(id);

            if (student == null)
                return null;

            var dto = new StudentReponseDTO
            {
                StudentDTO = _mapper.Map<StudentResDTO>(student),
                AddressDTO = student.Addresses != null ? _mapper.Map<List<AddressDTO>>(student.Addresses) : null,
                GuardianDTO = student.Guardian != null ? _mapper.Map<GuardianDTO>(student.Guardian) : null,
                SecondaryInfoDTO = student.SecondaryInfo != null ? _mapper.Map<SecondaryInfoDTO>(student.SecondaryInfo) : null,
                CitizenshipDTO = student.Citizenship != null ? _mapper.Map<CitizenshipDTO>(student.Citizenship) : null,
                ScholarshipDTO = student.Scholarship != null ? _mapper.Map<ScholarshipDTO>(student.Scholarship) : null,
                EmergencyDTO = student.Emergency != null ? _mapper.Map<EmergencyDTO>(student.Emergency) : null,
                EthnicityDTO = student.Ethnicity != null ? _mapper.Map<EthnicityDTO>(student.Ethnicity) : null,
                AcademicEnrollmentDTO = student.AcademicEnrollment != null ? _mapper.Map<AcademicEnrollmentDTO>(student.AcademicEnrollment) : null,
                AcademicHistories = student.AcademicHistories != null ? _mapper.Map<List<AcademicHistoryDTO>>(student.AcademicHistories) : null,
                BankDTO = student.Bank != null ? _mapper.Map<BankDTO>(student.Bank) : null
            };

            return dto;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);

            if (student != null)
            {
                _unitOfWork.Students.Delete(student);
                await _unitOfWork.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, CreateStudentDTO dto)
        {


             await _unitOfWork.BeginTransactionAsync();


            try
            {

                var student = await _unitOfWork.StudentRepository.GetById(id);
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






                //_mapper.Map(dto.StudentDTO, student);

                _mapper.Map(dto.BankDTO, student.Bank);

                _mapper.Map(dto.ScholarshipDTO, student.Scholarship);

                _mapper.Map(dto.AcademicEnrollmentDTO, student.AcademicEnrollment);

                _mapper.Map(dto.CitizenshipDTO, student.Citizenship);

                _mapper.Map(dto.SecondaryInfoDTO, student.SecondaryInfo);

                _mapper.Map(dto.GuardianDTO, student.Guardian);

                _mapper.Map(dto.EmergencyDTO, student.Emergency);

                _mapper.Map(dto.EthnicityDTO, student.Ethnicity);


                foreach (var address in student.Addresses)
                {
                    foreach (var dtoAddress in dto.AddressDTO)
                    {
                        if (address.AddressType == AddressType.Permanent && dtoAddress.IsPermanent == 1)
                        {
                            _mapper.Map(dtoAddress, address);
                        }
                        else if (address.AddressType == AddressType.Temporary && dtoAddress.IsPermanent == 0)
                        {
                            _mapper.Map(dtoAddress, address);
                        }
                        else if (address.AddressType == AddressType.Both)
                        {
                            _mapper.Map(dtoAddress, address);
                        }
                    }
                }



                var documentList = new List<Document>();


                if (dto.DocumentsDTO.Signature != null)
                {
                    var sigFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Signature);

                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
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
                        FileName = ccFile,
                        FilePath = $"/uploads/students/{ccFile}",
                        DocumentType = DocumentType.CharacterCertificate,
                        ContentType = dto.DocumentsDTO.CharacterCertificate.ContentType
                    });

                    Console.WriteLine("Documents made 3 !");
                }


                await _unitOfWork.Documents.AddRangeAsync(documentList);

                // _unitOfWork.Students.Update(student);


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

                await _unitOfWork.Students.AddAsync(student);
                await _unitOfWork.SaveAsync();



                if (dto.AddressDTO != null && dto.AddressDTO.Any())
                {
                    if (dto.AddressDTO.Count == 1)
                    {
                        var addressDto = dto.AddressDTO.First();

                        var address = _mapper.Map<Address>(addressDto);
                        address.StudentId = student.Id;
                        address.AddressType = AddressType.Both;

                        await _unitOfWork.Addresses.AddAsync(address);
                    }
                    
                    else
                    {
                        foreach (var addressDto in dto.AddressDTO)
                        {
                            var address = _mapper.Map<Address>(addressDto);
                            address.StudentId = student.Id;
                            address.AddressType = addressDto.IsPermanent == 1
                                ? AddressType.Permanent
                                : AddressType.Temporary;

                            await _unitOfWork.Addresses.AddAsync(address);
                        }
                    }
                }


                // Handle Guardian
                var guardian = _mapper.Map<Guardian>(dto.GuardianDTO);
                guardian.StudentId = student.Id;
                await _unitOfWork.Guardians.AddAsync(guardian);

                // Handle Secondary Info
                var secondary = _mapper.Map<SecondaryInfo>(dto.SecondaryInfoDTO);
                secondary.StudentId = student.Id;
           
                await _unitOfWork.SecondaryInfo.AddAsync(secondary);

                // Handle Scholarship
                var scholarship = _mapper.Map<Scholarship>(dto.ScholarshipDTO);
                scholarship.StudentId = student.Id;
                scholarship.ScholarshipAmount = dto.ScholarshipDTO.ScholarshipAmount;
                scholarship.ScholarshipType = dto.ScholarshipDTO.ScholarshipType;
                scholarship.ScholarshipProviderName = dto.ScholarshipDTO.ScholarshipProviderName;
                await _unitOfWork.Scholarships.AddAsync(scholarship);

                // Handle Emergency
                var emergency = _mapper.Map<Emergency>(dto.EmergencyDTO);
                emergency.StudentId = student.Id;
                await _unitOfWork.Emergency.AddAsync(emergency);

                // Handle Ethnicity
                var ethnicity = _mapper.Map<Ethnicity>(dto.EthnicityDTO);
                ethnicity.StudentId = student.Id;
                await _unitOfWork.Ethinicities.AddAsync(ethnicity);


                // Handle Bank Details 

                var bank = _mapper.Map<Bank>(dto.BankDTO);
                bank.StudentId = student.Id;
                await _unitOfWork.Banks.AddAsync(bank);


                var documentList = new List<Document>();


                if (dto.DocumentsDTO.Signature != null)
                {
                    var sigFile = await _imageService.SaveStudentImageAsync(dto.DocumentsDTO.Signature);
                    documentList.Add(new Document
                    {
                        StudentId = student.Id,
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
                await _unitOfWork.AcademicEnrollments.AddAsync(academic_enrollment);

            


                foreach (var academichistory in dto.AcademicHistories)
                {
                    var AcademicHistoryData = new AcademicHistory
                    {
                        StudentId = student.Id,
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
                    await _unitOfWork.Citizenships.AddAsync(citizenshipdata);
                }



               


                //await _unitOfWork.SaveAsync();
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
