using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface ITestValidationService
    {
        bool ValidateTotalScore(TestScores testScores);
        bool ValidateDivisionScore(ApplicantDivision division, TestScores testScores);
    }
}
