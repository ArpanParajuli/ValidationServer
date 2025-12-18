using Microsoft.EntityFrameworkCore;
using ValidationServer.Data;
using ValidationServer.Models.Students;
using ValidationServer.DTOs;
using AutoMapper;
using ValidationServer.DTOs.Response;
namespace ValidationServer.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mapper;
        public StudentRepository(AppDbContext appDbContext , IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
          
        }
      
        public async Task<Student?> GetById(int id)
        {

            var student = await _appDbContext.Students
                .Include(s => s.Addresses)
                .Include(s => s.Guardians)
                .Include(s => s.SecondaryInfo)
                .Include(s => s.Citizenship)
                .Include(s => s.Scholarship)
                .Include(s => s.Emergency)
                .Include(s => s.Ethnicity)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.AcademicHistories)
                .Include(s => s.Bank)
                .Include(s => s.Awards)
                .Include(s => s.Interests)
                .Include(s => s.OtherInformation)
                .FirstOrDefaultAsync(s => s.Id == id);


            if (student == null)
                return null;




            return student;

        }

    }
}
