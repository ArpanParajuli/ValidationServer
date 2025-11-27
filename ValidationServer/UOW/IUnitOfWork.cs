
using ValidationServer.Models.Students;
using ValidationServer.Repositories;

namespace ValidationServer.UOW
{
    public interface IUnitOfWork
    {
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


        Task<int> SaveAsync();
    }
}
