using MediatR;

namespace ValidationServer.Application.Commands.Students.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<bool>;
}
