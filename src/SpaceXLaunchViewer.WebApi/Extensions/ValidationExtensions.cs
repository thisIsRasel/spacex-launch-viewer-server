using FluentValidation;

namespace SpaceXLaunchViewer.WebApi.Extensions;

public static class ValidationExtensions
{
    public static ValidationProblemDetails ToProblemDetails(
        this ValidationException exception)
    {
        var error = new ValidationProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Status = 400
        };

        foreach (var item in exception.Errors)
        {
            if (error.Errors.ContainsKey(item.PropertyName))
            {
                error.Errors[item.PropertyName]
                    = error.Errors[item.PropertyName]
                        .Concat(new[] { item.ErrorMessage }).ToArray();
            }

            error.Errors.Add(new KeyValuePair<string, string[]>(
                item.PropertyName,
                new[] { item.ErrorMessage }));
        }

        return error;
    }
}

public class ValidationProblemDetails
{
    public string Type { get; set; } = default!;

    public int Status { get; set; } = default!;

    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
}