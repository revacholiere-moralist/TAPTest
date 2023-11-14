using Domain.Enums;

namespace Domain.Entities
{
    public class ApplicantTestResult
    {
        public ApplicantDivision ApplicantType { get; set; }
        public TestScores TestScores { get; set; }
    }

}
