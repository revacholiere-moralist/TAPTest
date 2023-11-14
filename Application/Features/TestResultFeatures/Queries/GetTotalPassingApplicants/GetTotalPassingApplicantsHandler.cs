using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.TestResultFeatures.Queries.GetTotalPassingApplicants
{
    public class GetTotalPassingApplicantsHandler : IRequestHandler<GetTotalPassingApplicantsQuery, int>
    {
        private readonly ITestValidationService _testValidationService;
        private readonly IInputParserService _inputParserService;
        public GetTotalPassingApplicantsHandler(ITestValidationService testValidationService, IInputParserService inputParserService)
        {
            _testValidationService = testValidationService;
            _inputParserService = inputParserService;
        }
        public Task<int> Handle(GetTotalPassingApplicantsQuery request, CancellationToken cancellationToken)
        {
            int passingApplicantCount = 0;
            var testResults = _inputParserService.ParseInputToTestResult(request.InputString);
            foreach (var testResult in testResults)
            {
                if (!_testValidationService.ValidateTotalScore(testResult.TestScores))
                {
                    continue;
                }
                if (!_testValidationService.ValidateDivisionScore(testResult.ApplicantType, testResult.TestScores))
                {
                    continue;
                }

                passingApplicantCount++;
            }
            // MediatR doesn't provide synchronous Handler
            return Task.FromResult(passingApplicantCount);
        }

    }
}
