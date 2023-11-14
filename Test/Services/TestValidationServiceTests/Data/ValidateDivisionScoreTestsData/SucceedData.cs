using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.TestValidationServiceTests.Data.ValidateDivisionScoreTestsData
{
    public class SucceedData : TheoryData<ApplicantDivision, TestScores, bool>
    {
        public SucceedData()
        {
            // Data 1 (passed, division: Science, total science score: 165)
            var testScore1 = new TestScores
            {
                English = 80,
                Math = 95,
                Science = 70,
                Japanese = 70,
                Geography = 75
            };
            Add(ApplicantDivision.Science, testScore1, true);

            // Data 2 (failed, division: Science, total science score: 155)
            var testScore2 = new TestScores
            {
                English = 100,
                Math = 90,
                Science = 65,
                Japanese = 45,
                Geography = 70
            };
            Add(ApplicantDivision.Science, testScore2, false);

            // Data 3 (passed, division: Humanities, total science score: 180)
            var testScore3 = new TestScores
            {
                English = 80,
                Math = 95,
                Science = 70,
                Japanese = 90,
                Geography = 90
            };
            Add(ApplicantDivision.Humanities, testScore3, true);

            // Data 4 (failed, division: Humanities, total science score: 95)
            var testScore4 = new TestScores
            {
                English = 100,
                Math = 90,
                Science = 65,
                Japanese = 60,
                Geography = 35
            };
            Add(ApplicantDivision.Humanities, testScore4, false);
        }
    }
}
