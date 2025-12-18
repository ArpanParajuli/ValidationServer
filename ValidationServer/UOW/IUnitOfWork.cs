
using Microsoft.EntityFrameworkCore.Storage;
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public interface IUnitOfWork
    {
       IGenericRepository<Student> Students { get; }
       IGenericRepository<Address> Addresses { get; }
       IGenericRepository<Guardian> Guardians { get; }
       IGenericRepository<Scholarship> Scholarships { get; }
       IGenericRepository<Disability> Disabilities { get; }
       IGenericRepository<Bank> Banks { get; }
       IGenericRepository<Emergency> Emergency { get; }
       IGenericRepository<SecondaryInfo> SecondaryInfo { get; }
       IGenericRepository<Ethnicity> Ethinicities { get; }
       IGenericRepository<Nationality> Nationalities { get; }
       IGenericRepository<Citizenship> Citizenships { get; }

       IGenericRepository<Document> Documents { get; }

       IGenericRepository<AcademicEnrollment> AcademicEnrollments { get; }

       IGenericRepository<AcademicHistory> AcademicHistorys { get; }

       IStudentRepository StudentRepository { get; }

        IGenericRepository<Award> Awards { get; }

         IGenericRepository<OtherInformation> OtherInformations { get; }

        IGenericRepository<Interest> Interests { get; }


        Task<int> SaveAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
