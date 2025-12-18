using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using ValidationServer.Models.Students;

namespace ValidationServer.DTOs
{
    public class CreateStudentDTO
    {
        public  StudentDTO StudentDTO { get; set; } = new();
        public List<AddressDTO> AddressDTO { get; set; } = new();
        public List<GuardianDTO> GuardianDTO { get; set; } = new();
        public SecondaryInfoDTO SecondaryInfoDTO { get; set; } = new();
        public CitizenshipDTO CitizenshipDTO { get; set; } = new();
        public ScholarshipDTO ScholarshipDTO { get; set; } = new();
        public EmergencyDTO EmergencyDTO { get; set; } = new();
        public EthnicityDTO EthnicityDTO { get; set; } = new();
        public DocumentsDTO DocumentsDTO { get; set; } = new();
        public AcademicEnrollmentDTO AcademicEnrollmentDTO { get; set; } = new();
        public List<AcademicHistoryDTO> AcademicHistories { get; set; } = new();
        public BankDTO BankDTO { get; set; } = new();
        public List<AwardDTO> AwardDTO { get; set;} = new();

        public List<InterestDTO> InterestDTO { get; set;} = new();

        public OtherInformationDTO OtherInformationDTO { get; set; } = new();





        //public DbSet<Financial> Financials { get; set; }
        //public DbSet<Fee> Fees { get; set; }
        //public DbSet<Disability> Disabilities { get; set; }

        //public DbSet<Nationality> Nationalities { get; set; }


    }
}