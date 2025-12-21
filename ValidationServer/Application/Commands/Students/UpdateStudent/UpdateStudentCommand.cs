
using MediatR;
using ValidationServer.DTOs;

namespace ValidationServer.Application.Commands.Students.UpdateStudent
{
    public record UpdateStudentCommand(Guid Id , StudentUpdateDTO request) : IRequest<bool>;
}
