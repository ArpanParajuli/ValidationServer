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

        //public async Task<Student?> GetById(int id)
        //{

        //    var student = await _appDbContext.Students
        //        .Include(s => s.Addresses.Where(s => !s.IsDeleted))
        //        .Include(s => s.Guardians.Where(s => !s.IsDeleted))
        //        .Include(s => s.SecondaryInfo.Where(s => !s.IsDeleted))
        //        .Include(s => s.Citizenship)
        //        .Include(s => s.Scholarship)
        //        .Include(s => s.Emergency)
        //        .Include(s => s.Ethnicity)
        //        .Include(s => s.AcademicEnrollment)
        //        .Include(s => s.AcademicHistories)
        //        .Include(s => s.Bank)
        //        .Include(s => s.Awards)
        //        .Include(s => s.Interests)
        //        .Include(s => s.OtherInformation)
        //        .Include(s => s.Documents)
        //        .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted) ;


        //    if (student == null)
        //        return null;




        //    return student;

        //}

        public IQueryable<Student> GetAllStudentsFiltered()
        {
            return  _appDbContext.Students.Where(s => !s.IsDeleted);              
        }

       

        public async Task<Student?> GetById(int id)
        {
            return  await _appDbContext.Students
                .Include(s => s.Addresses.Where(a => !a.IsDeleted))
                .Include(s => s.Guardians.Where(g => !g.IsDeleted))
                .Include(s => s.AcademicHistories.Where(h => !h.IsDeleted))
                .Include(s => s.Awards.Where(a => !a.IsDeleted))
                .Include(s => s.Interests.Where(i => !i.IsDeleted))
                .Include(s => s.Documents.Where(d => !d.IsDeleted))

       
                .Include(s => s.SecondaryInfo)
                .Include(s => s.Citizenship)
                .Include(s => s.Scholarship)
                .Include(s => s.Emergency)
                .Include(s => s.Ethnicity)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.Bank)
                .Include(s => s.OtherInformation)

                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<Student?> GetByOwnerId(Guid OwnerId)
        {

            return await _appDbContext.Students
                  .Include(s => s.Addresses.Where(a => !a.IsDeleted))
                  .Include(s => s.Guardians.Where(g => !g.IsDeleted))
                  .Include(s => s.AcademicHistories.Where(h => !h.IsDeleted))
                  .Include(s => s.Awards.Where(a => !a.IsDeleted))
                  .Include(s => s.Interests.Where(i => !i.IsDeleted))
                  .Include(s => s.Documents.Where(d => !d.IsDeleted))


                  .Include(s => s.SecondaryInfo)
                  .Include(s => s.Citizenship)
                  .Include(s => s.Scholarship)
                  .Include(s => s.Emergency)
                  .Include(s => s.Ethnicity)
                  .Include(s => s.AcademicEnrollment)
                  .Include(s => s.Bank)
                  .Include(s => s.OtherInformation)

                  .FirstOrDefaultAsync(s => s.OwnerId == OwnerId && !s.IsDeleted);

        }

    }
}
