
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }
        IGenericRepository<PermanentAddress> PermanentAddress { get; }
        IGenericRepository<TemporaryAddress> TemporaryAddress { get; }
        IGenericRepository<Parent> Parents { get; }
        IGenericRepository<Guardian> Guardians { get; }
        IGenericRepository<Scholarship> Scholarships { get; }
        IGenericRepository<Disability> Disabilities { get; }
        IGenericRepository<Bank> Banks { get; }
        IGenericRepository<Emergency> Emergency { get; }

        IGenericRepository<SecondaryInfo> SecondaryInfo { get;}

        IGenericRepository<Ethnicity> Ethinicities { get; }

        Task<int> SaveAsync();
    }
}
