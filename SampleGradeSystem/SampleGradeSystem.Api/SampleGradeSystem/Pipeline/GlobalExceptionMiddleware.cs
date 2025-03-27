using CSharpFunctionalExtensions;
using System.Net;

namespace SampleGradeSystem.Pipeline;
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var response = Result.Failure($"Some error occured: {exception.Message}");

        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(jsonResponse);
    }

}
