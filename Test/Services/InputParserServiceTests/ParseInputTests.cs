using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Infrastructure.Services;
using Newtonsoft.Json;
using Test.Services.InputParserServiceTests.Data.ParseInputTestsData;
using static System.Net.Mime.MediaTypeNames;

namespace Test.Services.InputParserServiceTests
{
    public class ParseInputTests
    {
        // Arrange
        readonly InputParserService service = new InputParserService();
        readonly Type badRequestException = typeof(BadRequestException);

        [Theory]
        [ClassData(typeof(SucceedData))]
        public void ShouldSucceedParseInput(string inputString, List<ApplicantTestResult> expectedApplicantTestResults)
        {
            // Act
            var actualTestApplicantResult = service.ParseInputToTestResult(inputString);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(actualTestApplicantResult), JsonConvert.SerializeObject(expectedApplicantTestResults));
        }

        [Theory]
        [ClassData(typeof(InvalidInputLengthData))]
        public void ShouldFailInvalidInputLength(string inputString)
        {
            // Act and Assert
            var ex = Assert.Throws<BadRequestException>(() => {
                service.ParseInputToTestResult(inputString);
            });
            Assert.Equal("Input string is not valid.", ex.ErrorMessage);
        }

        [Theory]
        [ClassData(typeof(InvalidDivisionData))]
        public void ShouldFailInvalidDivision(string inputString)
        {
            // Act and Assert
            var ex = Assert.Throws<BadRequestException>(() => {
                service.ParseInputToTestResult(inputString);
            });
            Assert.Equal("Please input valid applicant division.", ex.ErrorMessage);

        }

        [Theory]
        [ClassData(typeof(InvalidScoresData))]
        public void ShouldFailInvalidScores(string inputString, string errorMessage)
        {
            // Act and Assert
            var ex = Assert.Throws<BadRequestException>(() => {
                service.ParseInputToTestResult(inputString);
            });
            Assert.Equal(errorMessage, ex.ErrorMessage);

        }



    }
}
