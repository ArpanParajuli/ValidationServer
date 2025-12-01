using ValidationServer.Data;
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Student> Students { get; }
        public IGenericRepository<Address> Addresses { get; }
        public IGenericRepository<Guardian> Guardians { get; }
        public IGenericRepository<Scholarship> Scholarships { get; }
        public IGenericRepository<Disability> Disabilities { get; }
        public IGenericRepository<Bank> Banks { get; }
        public IGenericRepository<Emergency> Emergency { get; }
        public IGenericRepository<SecondaryInfo> SecondaryInfo { get; }
        public IGenericRepository<Ethnicity> Ethinicities { get; }
        public IGenericRepository<Nationality> Nationalities { get; }
        public IGenericRepository<Citizenship> Citizenships { get; }

        public IGenericRepository<Document> Documents { get; }

        public IGenericRepository<AcademicEnrollment> AcademicEnrollments { get; }

        public IGenericRepository<AcademicHistory> AcademicHistorys { get; }


        public UnitOfWork(AppDbContext context,
            IGenericRepository<Student> students,
            IGenericRepository<Address> addresses,
            IGenericRepository<Guardian> guardians,
            IGenericRepository<Scholarship> scholarships,
            IGenericRepository<Disability> disabilities,
            IGenericRepository<Bank> banks,
            IGenericRepository<Emergency> emergency,
            IGenericRepository<SecondaryInfo> secondaryInfo,
            IGenericRepository<Ethnicity> ethinicities,
            IGenericRepository<Nationality> nationalities,
            IGenericRepository<Citizenship> citizenships,
            IGenericRepository<Document> documents,
            IGenericRepository<AcademicHistory> academicHistorys,
            IGenericRepository<AcademicEnrollment> academicEnrollments
            )
        {
            _context = context;
            Students = students;
            Addresses = addresses;
            Guardians = guardians;
            Scholarships = scholarships;
            Disabilities = disabilities;
            Banks = banks;
            Emergency = emergency;
            SecondaryInfo = secondaryInfo;
            Ethinicities = ethinicities;
            Nationalities = nationalities;
            Citizenships = citizenships;
            Documents = documents;
            AcademicEnrollments = academicEnrollments;
            AcademicHistorys = academicHistorys;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}