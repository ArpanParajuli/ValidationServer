using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;
using ValidationServer.Data;
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private  IDbContextTransaction _transaction;
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


        public IStudentRepository StudentRepository { get; }


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
            IGenericRepository<AcademicEnrollment> academicEnrollments,
            IStudentRepository studentRepository
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

            StudentRepository = studentRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();

            return _transaction;
        }

        public  async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }

            catch
            {
                await RollbackTransactionAsync();
                Console.WriteLine("Transaction commit failed. Rolled back the transaction.");
                throw;
            }
        }
         
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}