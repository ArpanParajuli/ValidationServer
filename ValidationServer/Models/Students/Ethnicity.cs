

namespace ValidationServer.Models.Students
{
  public class Ethnicity : BaseEntity
    {
        //public int Id {get; set;}
        public string EthnicityName { get; set; } = string.Empty;
        public string EthnicityGroup { get; set; } = string.Empty;
        public int StudentId {get; set;}
        public Student Student {get; set;}

    }
}