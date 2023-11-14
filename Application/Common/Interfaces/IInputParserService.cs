using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IInputParserService
    {
        List<ApplicantTestResult> ParseInputToTestResult(string inputString);
    }
}
