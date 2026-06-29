using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace API.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException vex)
        {
            await HandleValidationException(context, vex);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static async Task HandleValidationException(HttpContext context, ValidationException vex)
    {
        var validationErrors = new Dictionary<string, string[]>();

        if (vex.Errors is not null)
        {
            foreach (ValidationFailure? error in vex.Errors)
            {
                if (validationErrors.TryGetValue(error.PropertyName, out string[]? existingErrors))
                {
                    validationErrors[error.PropertyName] = [.. existingErrors, error.ErrorMessage];
                }
                else
                {
                    validationErrors[error.PropertyName] = [error.ErrorMessage];
                }
            }
        }

        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        var validationProblemDetails = new ValidationProblemDetails(validationErrors)
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "ValidationFailure",
            Title = "Validation error",
            Detail = "One or more validation errors occurred"
        };

        await context.Response.WriteAsJsonAsync(validationProblemDetails);
    }
}
