using Domain.Entities;
using Domain.Enums;

namespace Test.Services.InputParserServiceTests.Data.ParseInputTestsData
{
    public class SucceedData : TheoryData<string, List<ApplicantTestResult>>
    {
        public SucceedData()
        {
            // Data 1 (single applicant test result)
            var input1 = "l 52 44 70 65 100";
            var expected1 = new List<ApplicantTestResult>();
            expected1.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 52,
                    Math = 44,
                    Science = 70,
                    Japanese = 65,
                    Geography = 100
                }
            });

            Add(input1, expected1);

            // Data 2 (multiple applicant test result)
            var input2 = "S 70 78 82 57 74\nL 68 81 81 60 78\ns 63 76 55 80 75";
            var expected2 = new List<ApplicantTestResult>();
            expected2.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Science,
                TestScores = new TestScores
                {
                    English = 70,
                    Math = 78,
                    Science = 82,
                    Japanese = 57,
                    Geography = 74
                }
            });
            expected2.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Humanities,
                TestScores = new TestScores
                {
                    English = 68,
                    Math = 81,
                    Science = 81,
                    Japanese = 60,
                    Geography = 78
                }
            });
            expected2.Add(new ApplicantTestResult
            {
                ApplicantType = ApplicantDivision.Science,
                TestScores = new TestScores
                {
                    English = 63,
                    Math = 76,
                    Science = 55,
                    Japanese = 80,
                    Geography = 75
                }
            });


            Add(input2, expected2);
        }
    };
}
