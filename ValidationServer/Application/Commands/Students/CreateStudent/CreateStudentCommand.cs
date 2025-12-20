using ValidationServer.DTOs;
using MediatR;

namespace ValidationServer.Application.Commands.Students.CreateStudent
{
    public record CreateStudentCommand(CreateStudentDTO Dto) : IRequest<bool>;
}
