using Application.Common.Options;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Test.Services.TestValidationServiceTests.Data.ValidateDivisionScoreTestsData;

namespace Test.Services.TestValidationServiceTests
{
    public class ValidateTotalScoreTests
    {
        // Mock Options
        IOptions<MinimumScoreOptions> minimumScoreOptions = Options.Create<MinimumScoreOptions>(new MinimumScoreOptions
        {
            MinimumTotalScore = 350,
            MinimumHumanitiesScore = 160,
            MinimumScienceScore = 160
        });

        [Theory]
        [ClassData(typeof(SucceedData))]
        public void ShouldSucceedValidateTotalScore(ApplicantDivision division, TestScores testScores, bool expectedResult)
        {
            // Arrange
            var service = new TestValidationService(minimumScoreOptions);

            // Act
            var actualResult = service.ValidateDivisionScore(division, testScores);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
