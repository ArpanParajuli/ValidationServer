using Microsoft.AspNetCore.Mvc;
using ValidationServer.DTOs;
using ValidationServer.Models.Students;
using ValidationServer.DTOs.Response;

namespace ValidationServer.Services
{
    public interface IStudentService
    {
        Task<bool> Create(CreateStudentDTO dto);

        Task<StudentReponseDTO?> GetStudentByIdAsync(Guid id);

        Task<bool> Update(Guid OwnerId, StudentUpdateDTO dto);


        Task<bool> Delete(Guid id);

        Task<IEnumerable<Student>> GetAllStudentAsync();



        
    }
}
