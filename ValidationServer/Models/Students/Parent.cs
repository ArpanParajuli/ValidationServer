namespace ValidationServer.Models.Students
{
    public class Parent
    {
        public int Id { get; set; }

        // ------------- Father Details -------------
        public string FatherFullName { get; set; } = string.Empty;
        public string? FatherOccupation { get; set; }
        public string? FatherDesignation { get; set; }
        public string? FatherOrganization { get; set; }
        public string FatherMobileNumber { get; set; } = string.Empty;
        public string? FatherEmail { get; set; }

        // ------------- Mother Details -------------
        public string MotherFullName { get; set; } = string.Empty;
        public string? MotherOccupation { get; set; }
        public string? MotherDesignation { get; set; }
        public string? MotherOrganization { get; set; }
        public string MotherMobileNumber { get; set; } = string.Empty;
        public string? MotherEmail { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
