using Domain.Entities;

namespace Test.Services.TestValidationServiceTests.Data.ValidateTotalScoreTestsData
{
    public class SucceedData : TheoryData<TestScores, bool>
    {
        public SucceedData()
        {
            // Data 1 (passed, total score: 380)
            var applicantTestResult1 = new TestScores
            {
                English = 80,
                Math = 95,
                Science = 60,
                Japanese = 70,
                Geography = 75
            };
            Add(applicantTestResult1, true);

            // Data 2 (failed, total score: 330)
            var applicantTestResult2 = new TestScores
            {
                English = 100,
                Math = 65,
                Science = 50,
                Japanese = 45,
                Geography = 70
            };
            Add(applicantTestResult2, false);
        }
    }
}
