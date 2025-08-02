using System.Security.Claims;

namespace TicketManagement.API.Middlewares;

public class CurrentUserMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = context.User.FindFirstValue(ClaimTypes.Email);
            var role = context.User.FindFirstValue(ClaimTypes.Role);

            context.Items["UserId"] = userId;
            context.Items["UserEmail"] = email;
            context.Items["UserRole"] = role;
        }

        await _next(context);
    }
}
