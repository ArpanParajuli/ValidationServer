
using MediatR;
using ValidationServer.DTOs.Response;

namespace ValidationServer.Application.Queries.GetStudentById
{
    public record GetStudentByIdCommand(Guid Id) : IRequest<StudentReponseDTO?>;
}
