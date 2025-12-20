using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ValidationServer.Application.Commands.Students.CreateStudent;
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
        private readonly IMediator _mediatR;

        public StudentController(IStudentService studentService , IMediator mediatR)
        {
            _studentService = studentService;
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var obj = await _studentService.GetAllStudentAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var obj = await _studentService.GetStudentByIdAsync(id);

            return Ok(obj);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStudentDTO dto)
        {

            CreateStudentCommand command = new CreateStudentCommand(dto);


            //var IsSuccess =  await _studentService.Create(dto);

            var IsSuccess = await _mediatR.Send(command);

            if (!IsSuccess)
            {
                return BadRequest(new { message = "Failed to create student" });
            }

            return Ok(new { message = "Student created successfully" });
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id , [FromForm] StudentUpdateDTO dto)
        {
           var IsSuccess =  await _studentService.Update(id,dto);

            if(!IsSuccess)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(new { message = "Student Updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var IsSuccess = await _studentService.Delete(id);

            if (!IsSuccess)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(new { message = "Student deleted! successfully" });
        }
    }
}