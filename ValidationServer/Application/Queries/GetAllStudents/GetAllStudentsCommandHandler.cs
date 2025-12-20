using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationServer.Data;
using ValidationServer.Models.Students;

namespace ValidationServer.Application.Queries.GetAllStudents
{
    public class GetAllStudentsCommandHandler : IRequestHandler<GetAllStudentsCommand , IEnumerable<Student?>>
    {
        private readonly AppDbContext _context;
        public GetAllStudentsCommandHandler(AppDbContext context) { _context = context; }


        public async Task<IEnumerable<Student?>> Handle(GetAllStudentsCommand command , CancellationToken ct)
        {
            return await _context.Students.AsNoTracking().Where(s => !s.IsDeleted).ToListAsync(ct);
        }
    }
}
