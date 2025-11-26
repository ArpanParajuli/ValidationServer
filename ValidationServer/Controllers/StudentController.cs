using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidationServer.DTOs;
using ValidationServer.Models.Students;
using ValidationServer.UOW;

namespace ValidationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var obj = await _unitOfWork.Students.GetAllAsync();
            return Ok(obj);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateStudentDTOs dto)
        {
            var student = _mapper.Map<Student>(dto.studentDTO);
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.SaveAsync();

            var permanentAddress = _mapper.Map<PermanentAddress>(dto.permanentAddressDTO);
            permanentAddress.StudentId = student.Id;

            var temporaryAddress = _mapper.Map<TemporaryAddress>(dto.temporaryDTO);
            temporaryAddress.StudentId = student.Id;

            var parent = _mapper.Map<Parent>(dto.parentDTO);
            parent.StudentId = student.Id;

            var secondary = _mapper.Map<SecondaryInfo>(dto.secondaryInfoDTO);
            secondary.StudentId = student.Id;

            var scholarship = _mapper.Map<Scholarship>(dto.scholarshipDTO);
            scholarship.StudentId = student.Id;

            var emergency = _mapper.Map<Emergency>(dto.emergencyDTO);
            emergency.StudentId = student.Id;

            var ethnicity = _mapper.Map<Ethnicity>(dto.ethnicityDTO);
            ethnicity.StudentId = student.Id;

            await _unitOfWork.PermanentAddress.AddAsync(permanentAddress);
            await _unitOfWork.TemporaryAddress.AddAsync(temporaryAddress);
            await _unitOfWork.Parents.AddAsync(parent);
            await _unitOfWork.SecondaryInfo.AddAsync(secondary);
            await _unitOfWork.Scholarships.AddAsync(scholarship);
            await _unitOfWork.Emergency.AddAsync(emergency);
            await _unitOfWork.Ethinicities.AddAsync(ethnicity);

            await _unitOfWork.SaveAsync();


            return Ok("Student created successfully");
        }


    }


}