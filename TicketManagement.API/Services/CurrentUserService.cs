using TicketManagement.Application.Common;

namespace TicketManagement.API.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    public string? UserId =>
      _contextAccessor.HttpContext?.Items["UserId"]?.ToString();

    public string? Email => _contextAccessor.HttpContext?.Items["UserEmail"]?.ToString();

    public string? Role => _contextAccessor.HttpContext?.Items["UserRole"]?.ToString();
}