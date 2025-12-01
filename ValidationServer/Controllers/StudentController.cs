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
  
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var obj = new CreateStudentDTO();

            //var obj = await _studentService.GetAllStudentAsync();
            return Ok(obj);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStudentDTO dto)
        {
            await _studentService.Create(dto);
           return Ok(new { message = "Student created successfully" });
        }
    }
}