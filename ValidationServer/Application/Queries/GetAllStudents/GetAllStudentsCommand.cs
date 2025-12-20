using MediatR;
using ValidationServer.Models.Students;

namespace ValidationServer.Application.Queries.GetAllStudents
{
    public record GetAllStudentsCommand() : IRequest<IEnumerable<Student?>>;
}
