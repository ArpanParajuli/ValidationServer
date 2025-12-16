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
        //public async Task<StudentUpdateDTO?> GetById(int id)
        //{
        //    var studentEntity = await _appDbContext.Students
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    if (studentEntity == null)
        //        return null;

        //    // Load related data
        //    var address = await _appDbContext.Addresses.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var guardian = await _appDbContext.Guardians.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var secondary = await _appDbContext.SecondaryInfos.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var citizenship = await _appDbContext.Citizenships.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var scholarship = await _appDbContext.Scholarships.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var emergency = await _appDbContext.Emergencies.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var ethnicity = await _appDbContext.Ethnicities.FirstOrDefaultAsync(x => x.StudentId == id);
        //    var enrollment = await _appDbContext.AcademicEnrollments.FirstOrDefaultAsync(x => x.StudentId == id);

        //    var dto = new StudentUpdateDTO
        //    {
        //        StudentDTO = new StudentDTO
        //        {
        //            Email = studentEntity.Email,
        //            DateOfBirth = studentEntity.DateOfBirth,
        //            FirstName = studentEntity.FirstName,
        //            LastName = studentEntity.LastName,
        //            MiddleName = studentEntity.MiddleName,
        //            Gender = studentEntity.Gender,
        //            PrimaryMobile = studentEntity.PrimaryMobile,
        //            PlaceOfBirth = studentEntity.PlaceOfBirth
        //        },

        //        AddressDTO = address == null ? null : new AddressDTO
        //        {
        //            District = address.District,
        //            HouseNumber = address.HouseNumber,
        //            Municipality = address.Municipality,
        //            Province = address.Province,
        //            ToleStreet = address.ToleStreet,
        //            WardNumber = address.WardNumber
        //        },

        //        GuardianDTO = guardian == null ? null : new GuardianDTO
        //        {
        //            FullName = guardian.FullName,
        //            Relation = guardian.Relation,
        //            Email = guardian.Email,
        //            MobileNumber = guardian.MobileNumber,
        //            Occupation = guardian.Occupation
        //        },

        //        SecondaryInfoDTO = secondary == null ? null : new SecondaryInfoDTO
        //        {
        //            AlternateEmail = secondary.AlternateEmail,
        //            BloodGroup = secondary.BloodGroup,
        //            MaritalStatus = secondary.MaritalStatus,
        //            MiddleName = secondary.MiddleName,
        //            Religion = secondary.Religion,
        //            SecondaryMobile = secondary.SecondaryMobile
        //        },

        //        CitizenshipDTO = citizenship == null ? null : new CitizenshipDTO
        //        {
        //            CitizenshipIssueDate = citizenship.CitizenshipIssueDate,
        //            CitizenshipIssueDistrict = citizenship.CitizenshipIssueDistrict,
        //            CitizenshipNumber = citizenship.CitizenshipNumber
        //        },

        //        ScholarshipDTO = scholarship == null ? null : new ScholarshipDTO
        //        {
        //            ScholarshipAmount = scholarship.Amount,
        //            ScholarshipProviderName = scholarship.ProviderName,
        //            ScholarshipType = scholarship.Type
        //        },

        //        EmergencyDTO = emergency == null ? null : new EmergencyDTO
        //        {
        //            EmergencyContactName = emergency.EmergencyContactName,
        //            EmergencyContactNumber = emergency.EmergencyContactNumber,
        //            EmergencyContactRelation = emergency.EmergencyContactRelation
        //        },

        //        EthnicityDTO = ethnicity == null ? null : new EthnicityDTO
        //        {
        //            EthnicityGroup = ethnicity.EthnicityGroup,
        //            EthnicityName = ethnicity.EthnicityName
        //        },

        //        AcademicEnrollmentDTO = enrollment == null ? null : new AcademicEnrollmentDTO
        //        {
        //            AcademicStatus = (int)enrollment.AcademicStatus,
        //            EnrollDate = enrollment.EnrollDate,
        //            Faculty = enrollment.Faculty,
        //            Level = enrollment.Level,
        //            Program = enrollment.Program,
        //            Section = enrollment.Section,
        //            RegistrationNumber = enrollment.RegistrationNumber,
        //            RollNumber = enrollment.RollNumber,
        //            Semester = enrollment.Semester
        //        },

        //        AcademicHistories = null // You can load later
        //    };

        //    return dto;
        //}


        public async Task<Student?> GetById(int id)
        {

            var student = await _appDbContext.Students
                .Include(s => s.Addresses)
                .Include(s => s.Guardian)
                .Include(s => s.SecondaryInfo)
                .Include(s => s.Citizenship)
                .Include(s => s.Scholarship)
                .Include(s => s.Emergency)
                .Include(s => s.Ethnicity)
                .Include(s => s.AcademicEnrollment)
                .Include(s => s.AcademicHistories)
                .Include(s => s.Bank)
                .FirstOrDefaultAsync(s => s.Id == id);


            if (student == null)
                return null;




            return student;

        }

    }
}
