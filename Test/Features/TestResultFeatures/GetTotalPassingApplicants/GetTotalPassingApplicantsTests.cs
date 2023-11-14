using Application.Common.Interfaces;
using Application.Features.TestResultFeatures.Queries.GetTotalPassingApplicants;
using Domain.Entities;
using Domain.Enums;
using NSubstitute;
using NSubstitute.Extensions;
using Test.Features.TestResultFeatures.Data.GetTotalPassingApplicantsData;

namespace Test.Features.TestResultFeatures.GetTotalPassingApplicants
{
    public class GetTotalPassingApplicantsTests
    {
        [Theory]
        [ClassData(typeof(SucceedData))]
        public async Task ShouldSucceedGetTotalPassingApplicants(List<ApplicantTestResult> testResults, int expectedPassingApplicants)
        {
            // Arrange
            var inputParserServiceMock = Substitute.For<IInputParserService>();
            var testValidationServiceMock = Substitute.For<ITestValidationService>();

            // Mock Service
            inputParserServiceMock.ParseInputToTestResult(Arg.Any<string>()).Returns(testResults);

            // Simulate individual validations with English score -> when English score is 100, the applicant passed both validations.
            // When English score is 95, the applicant only passed total score validation, but not division score validation.
            // When English score is 90, the applicant only passed division score validation.
            testValidationServiceMock.ValidateTotalScore(Arg.Any<TestScores>()).Returns(false);
            testValidationServiceMock.ValidateTotalScore(Arg.Is<TestScores>(x => x.English == 100)).Returns(true);
            testValidationServiceMock.ValidateTotalScore(Arg.Is<TestScores>(x => x.English == 95)).Returns(true);

            testValidationServiceMock.ValidateDivisionScore(Arg.Any<ApplicantDivision>(), Arg.Any<TestScores>()).Returns(false);
            testValidationServiceMock.ValidateDivisionScore(Arg.Any<ApplicantDivision>(), Arg.Is<TestScores>(x => x.English == 100)).Returns(true);
            testValidationServiceMock.ValidateDivisionScore(Arg.Any<ApplicantDivision>(), Arg.Is<TestScores>(x => x.English == 90)).Returns(true);


            var handler = new GetTotalPassingApplicantsHandler(testValidationServiceMock, inputParserServiceMock);
            var query = new GetTotalPassingApplicantsQuery("Test String");

            // Act
            var actualResult = await handler.Handle(query, default);

            // Assert
            Assert.Equal(expectedPassingApplicants, actualResult);
        }
        
    }
}
