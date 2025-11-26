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
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<TemporaryAddress> TemporaryAddresses { get; set; }
        public DbSet<PermanentAddress> PermanentAddresses { get; set; }
        public DbSet<Financial> Financials { get; set; }

        public DbSet<SecondaryInfo> SecondaryInfos { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }

        public DbSet<Disability> Disabilities { get; set; }



        protected AppDbContext()
        {

        }


        
    }
}
