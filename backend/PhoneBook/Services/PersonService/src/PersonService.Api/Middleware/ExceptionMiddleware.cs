using FluentValidation;

namespace PersonService.Api.Middleware;
public sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        if (ex.GetType() == typeof(ValidationException))
        {
            return context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = ((ValidationException)ex).Errors.Select(s => new ValidatonError() { Field = s.PropertyName, Message = s.ErrorMessage }),
            }.ToString());
        }

        if (ex.GetType() == typeof(UnauthorizedAccessException))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
        }

        return context.Response.WriteAsync(new ErrorResult
        {
            Message = ex.Message,
        }.ToString());
    }
}