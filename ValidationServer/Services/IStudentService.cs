using Microsoft.AspNetCore.Mvc;
using ValidationServer.DTOs;
using ValidationServer.Models.Students;
using ValidationServer.DTOs.Response;

namespace ValidationServer.Services
{
    public interface IStudentService
    {
        Task<bool> Create(CreateStudentDTO dto);

        Task<StudentReponseDTO?> GetStudentByIdAsync(int id);

        Task<bool> Update(int id, CreateStudentDTO dto);

        Task<bool> Delete(int id);

        Task<IEnumerable<Student>> GetAllStudentAsync();



        
    }
}
