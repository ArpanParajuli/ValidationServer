using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidationServer.DTOs;
using ValidationServer.Models.Students;
using ValidationServer.Services;
using ValidationServer.UOW;

namespace ValidationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public StudentController(IMapper mapper, IUnitOfWork unitOfWork, IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var obj = await _unitOfWork.Students.GetAllAsync();
            return Ok(obj);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStudentDTO dto)
        {
            try
            {
                // Handle the student DTO
                var student = _mapper.Map<Student>(dto.StudentDTO);

                // Handle image upload - check if image is provided
                if (dto.StudentDTO.ImagePath != null && dto.StudentDTO.ImagePath.Length > 0)
                {
                    var imageUrl = await _imageService.SaveStudentImageAsync(dto.StudentDTO.ImagePath);
                    student.ImagePath = imageUrl;
                }
                else
                {
                    student.ImagePath = "/uploads/students/default-avatar.png";
                }

                await _unitOfWork.Students.AddAsync(student);
                await _unitOfWork.SaveAsync();

                // Handle Address
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

                await _unitOfWork.SaveAsync();

                return Ok(new { message = "Student created successfully", studentId = student.Id });
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Return detailed error information
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the student",
                    error = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}