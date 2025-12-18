using ValidationServer.DTOs;
using ValidationServer.DTOs.Response;
using ValidationServer.Models.Students;

namespace ValidationServer.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetById(int id);
        Task<Student?> GetByOwnerId(Guid OwnerId);

        IQueryable<Student> GetAllStudentsFiltered();
    }
}
