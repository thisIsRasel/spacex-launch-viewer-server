using FluentValidation;
using SpaceXLaunchViewer.Core.QueryModels;

namespace SpaceXLaunchViewer.Core.Validators;
public sealed class LaunchQueryValidator
    : AbstractValidator<LaunchQuery>
{
    public LaunchQueryValidator()
    {
        RuleFor(q => q.PageNumber).GreaterThan(0);
    }
}
