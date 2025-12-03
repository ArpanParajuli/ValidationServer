using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using ValidationServer.DTOs;
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
        public StudentService(IMapper mapper , IUnitOfWork unitOfWork , IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }


        public async Task Create(CreateStudentDTO dto)
        {
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

                var address = _mapper.Map<Address>(dto.AddressDTO);
                address.StudentId = student.Id;

                if (dto.AddressDTO.isTemporarySame)
                {
                    address.AddressType = AddressType.Both;
                }
                else
                {
                    address.AddressType = AddressType.Permanent;
                    var tempAddress = _mapper.Map<Address>(dto.AddressDTO);
                    tempAddress.StudentId = student.Id;
                    tempAddress.AddressType = AddressType.Temporary;
                    await _unitOfWork.Addresses.AddAsync(tempAddress);
                }

                await _unitOfWork.Addresses.AddAsync(address);

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
                await _unitOfWork.Scholarships.AddAsync(scholarship);

                // Handle Emergency
                var emergency = _mapper.Map<Emergency>(dto.EmergencyDTO);
                emergency.StudentId = student.Id;
                await _unitOfWork.Emergency.AddAsync(emergency);

                // Handle Ethnicity
                var ethnicity = _mapper.Map<Ethnicity>(dto.EthnicityDTO);
                ethnicity.StudentId = student.Id;
                await _unitOfWork.Ethinicities.AddAsync(ethnicity);


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
                        Level = (Level)academichistory.Level,
                        BoardUniversity = academichistory.BoardUniversity,
                        InstitutionName = academichistory.InstitutionName,
                        PassedYear = academichistory.PassedYear,
                        DivisionOrGPA = academichistory.DivisionOrGPA
                    };


                    await _unitOfWork.AcademicHistorys.AddAsync(AcademicHistoryData); 

            
                }


                var temporarydto = dto.TemporaryAddress;
                if (temporarydto != null)
                {
                    var tempAddr = new Address
                    {
                        StudentId = student.Id,
                        AddressType = AddressType.Temporary,
                        Province = temporarydto.Province,
                        District = temporarydto.District,
                        Municipality = temporarydto.Municipality,
                        WardNumber = temporarydto.WardNumber,
                        ToleStreet = temporarydto.ToleStreet,
                        HouseNumber = temporarydto.HouseNumber,
                    };
                    await _unitOfWork.Addresses.AddAsync(tempAddr);
                }


                var citizenshipdata = _mapper.Map<Citizenship>(dto.CitizenshipDTO);

                if(citizenshipdata != null)
                {
                    citizenshipdata.StudentId = student.Id;
                    await _unitOfWork.Citizenships.AddAsync(citizenshipdata);
                }
               

                  await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
 
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

    }
}
