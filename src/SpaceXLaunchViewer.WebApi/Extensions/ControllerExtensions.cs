using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace SpaceXLaunchViewer.WebApi.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ToOk<TResult>(this Result<TResult> result)
    {
        return result.Match<IActionResult>(
            records => new OkObjectResult(records),
            exception =>
            {
                if (exception is ValidationException validationException)
                {
                    return new BadRequestObjectResult(
                        validationException.ToProblemDetails());
                }

                return new StatusCodeResult(500);
            });
    }
}
