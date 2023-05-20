using FluentValidation;
using SpaceXLaunchViewer.Core.QueryModels;

namespace SpaceXLaunchViewer.Core.Validators;
public sealed class LaunchDetailQueryValidator
    : AbstractValidator<LaunchDetailQuery>
{
    public LaunchDetailQueryValidator()
    {
        RuleFor(q => q.FlightNumber).GreaterThan(0);
    }
}
