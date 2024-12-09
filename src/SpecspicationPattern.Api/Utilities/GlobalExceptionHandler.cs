using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpecspicationPattern.Api.Utilities.Exceptions;
using System.Diagnostics;

namespace SpecspicationPattern.Api.Utilities;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"Exception Type: {exception.GetType().Name}");
        Console.WriteLine($"Exception Message: {exception.Message}");

        httpContext.Response.StatusCode = exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            ApplicationException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        await httpContext.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Title = "An error occurred while processing your request",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions =
                {
                    ["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier,
                    ["requestId"] = httpContext.TraceIdentifier,
                    ["errors"] = exception switch
                    {
                        ValidationException validationException => validationException.Errors,
                        _ => null
                    }
                }
            }, cancellationToken: cancellationToken);

        return true;
    }
}