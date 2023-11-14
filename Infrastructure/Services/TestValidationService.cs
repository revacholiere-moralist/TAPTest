using Application.Common.Interfaces;
using Application.Common.Options;
using Domain.Entities;
using Domain.Enums;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class TestValidationService : ITestValidationService
    {
        private readonly MinimumScoreOptions _minimumScoreOptions;
        public TestValidationService(IOptions<MinimumScoreOptions> minimumScoreOptions)
        {
            _minimumScoreOptions = minimumScoreOptions.Value;
        }

        public bool ValidateTotalScore(TestScores testScores)
        {
            // Get all Properties
            var propsList = typeof(TestScores).GetProperties();
            int totalScore = 0;
            foreach (var property in propsList)
            {
                // Check if the property is integer just in case
                if (property.PropertyType == typeof(int))
                {
                    totalScore += Convert.ToInt32(property.GetValue(testScores, null));
                }

            }
            return totalScore >= _minimumScoreOptions.MinimumTotalScore;
        }

        public bool ValidateDivisionScore(ApplicantDivision division, TestScores testScores)
        {
            var scienceScore = testScores.Math + testScores.Science;
            var humanitiesScore = testScores.Japanese + testScores.Geography;
            switch (division)
            {
                case ApplicantDivision.Science:
                    return scienceScore >= _minimumScoreOptions.MinimumScienceScore;
                case ApplicantDivision.Humanities:
                    return humanitiesScore >= _minimumScoreOptions.MinimumHumanitiesScore;
                default:
                    return false;
            }
        }


    }
}
