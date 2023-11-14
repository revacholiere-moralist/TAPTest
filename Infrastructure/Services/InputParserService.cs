using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using System;
using System.Reflection;

namespace Infrastructure.Services
{
    public class InputParserService : IInputParserService
    {
        public List<ApplicantTestResult> ParseInputToTestResult(string inputString)
        {
            var applicantTestResults = new List<ApplicantTestResult>();
            var applicantTests = inputString.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var applicantTest in applicantTests)
            {
                var testDetails = applicantTest.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var applicantTestResult = new ApplicantTestResult
                {
                    TestScores = new TestScores()
                };

                // Validate the whole input string
                // Length should be all the number of Test Subjects Enum member + 1 for Applicant Division type
                if (testDetails.Length != Enum.GetNames(typeof(TestSubjects)).Length + 1)
                {
                    throw new BadRequestException("Input string is not valid.");
                }

                // Validate applicant division input string
                if (testDetails[0].ToLower() != "l" && testDetails[0].ToLower() != "s")
                {
                    throw new BadRequestException("Please input valid applicant division.");
                }

                applicantTestResult.ApplicantType = ApplicantDivision.Humanities;
                if (testDetails[0].ToLower() == "s")
                {
                    applicantTestResult.ApplicantType = ApplicantDivision.Science;
                }

                // Validate test scores input string
                for (var i = 1; i < testDetails.Length; i++)
                {
                    var score = 0;
                    if (!Int32.TryParse(testDetails[i], out score))
                    {
                        throw new BadRequestException("Please input a valid integer for each test score.");
                    }

                    if (score < 0 || score > 100)
                    {
                        throw new BadRequestException("Please input a value between 0 and 100 for each test score.");
                    }

                    var isEnumExist = Enum.IsDefined(typeof(TestSubjects), i);

                    if (!isEnumExist)
                    {
                        throw new IncompleteMasterDataException("Test subject master data is not found.");
                    }

                    var propertyName = ((TestSubjects)i).ToString();
                    var propertyInfo = applicantTestResult.TestScores.GetType().GetProperty(propertyName);

                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(applicantTestResult.TestScores, score);
                    }
                }
                applicantTestResults.Add(applicantTestResult);
            }
            return applicantTestResults;
        }
    }
}
