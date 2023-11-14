using MediatR;

namespace Application.Features.TestResultFeatures.Queries.GetTotalPassingApplicants
{
    public record GetTotalPassingApplicantsQuery(string InputString) : IRequest<int>;
}
