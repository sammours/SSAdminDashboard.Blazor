namespace SSAdminDashboard.Blazor.Middlewares;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using SSAdminDashboard.Domain.Users;

//Fix error handling snackbar
public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (UnauthorizedUserProviderException exception)
        {
            this.logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
        }
    }
}