using Microsoft.AspNetCore.Mvc;
using ValidationServer.DTOs;
using ValidationServer.Models.Students;

namespace ValidationServer.Services
{
    public interface IStudentService
    {
        Task Create(CreateStudentDTO dto);

        Task<IEnumerable<Student>> GetAllStudentAsync();



        
    }
}
