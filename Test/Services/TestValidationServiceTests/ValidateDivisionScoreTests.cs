using Application.Common.Options;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Test.Services.TestValidationServiceTests.Data.ValidateTotalScoreTestsData;

namespace Test.Services.TestValidationServiceTests
{
    public class ValidateDivisionScoreTests
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
        public void ShouldSucceedValidateTotalScore(TestScores testScores, bool expectedResult)
        {
            // Arrange
            var service = new TestValidationService(minimumScoreOptions);

            // Act
            var actualResult = service.ValidateTotalScore(testScores);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
