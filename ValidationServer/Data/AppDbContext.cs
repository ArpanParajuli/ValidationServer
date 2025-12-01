using Microsoft.EntityFrameworkCore;
using ValidationServer.Models.Students;
namespace ValidationServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<SecondaryInfo> SecondaryInfos { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<AcademicEnrollment> AcademicEnrollments { get; set; }
        public DbSet<AcademicHistory> AcademicHistorys { get; set; }





        protected AppDbContext()
        {

        }


        
    }
}
