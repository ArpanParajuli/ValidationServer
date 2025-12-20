using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Xml.Schema;
using ValidationServer.Data;

namespace ValidationServer.Application.Commands.Students.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand , bool>
    {
        private readonly AppDbContext _context;
        public DeleteStudentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand command , CancellationToken ct)
        {

            Console.WriteLine("Delete command handler!");
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.OwnerId == command.Id);

            if (student == null)
            {
                return false;
            }

            student.IsDeleted = true;

           await _context.SaveChangesAsync(ct);

            return true;
        }
    }
}
