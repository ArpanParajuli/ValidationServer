using ValidationServer.Data;
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Student> Students { get; }
        public IGenericRepository<PermanentAddress> PermanentAddress { get; }
        public IGenericRepository<TemporaryAddress> TemporaryAddress { get; }
        public IGenericRepository<Parent> Parents { get; }
        public IGenericRepository<Guardian> Guardians { get; }
        public IGenericRepository<Scholarship> Scholarships { get; }
        public IGenericRepository<Disability> Disabilities { get; }
        public IGenericRepository<Bank> Banks { get; }
        public IGenericRepository<Emergency> Emergency { get; }
        public IGenericRepository<SecondaryInfo> SecondaryInfo { get; }
        public IGenericRepository<Ethnicity> Ethinicities { get; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Students = new GenericRepository<Student>(_context);
            PermanentAddress = new GenericRepository<PermanentAddress>(_context);
            TemporaryAddress = new GenericRepository<TemporaryAddress>(_context);
            Parents = new GenericRepository<Parent>(_context);
            Guardians = new GenericRepository<Guardian>(_context);
            Scholarships = new GenericRepository<Scholarship>(_context);
            Disabilities = new GenericRepository<Disability>(_context);
            Banks = new GenericRepository<Bank>(_context);
            Emergency = new GenericRepository<Emergency>(_context);
            Ethinicities = new GenericRepository<Ethnicity>(_context);
            SecondaryInfo = new GenericRepository<SecondaryInfo>(_context); 
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
