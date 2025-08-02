using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Application.Common;
using TicketManagement.Domain.Base;
using TicketManagement.Domain.Domains.Tickets;
using TicketManagement.Domain.Domains.Users;
using TicketManagement.Infrastructure.Base;
using TicketManagement.Infrastructure.Common.Auth;
using TicketManagement.Infrastructure.Common.Security;
using TicketManagement.Infrastructure.Domains.Tickets;
using TicketManagement.Infrastructure.Domains.Users;

namespace TicketManagement.Infrastructure.SeedWorks;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>))
            .AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>))
            .AddScoped<ITicketReadRepository, TicketReadRepository>()
            .AddScoped<ITicketWriteRepository, TicketWriteRepository>()
            .AddScoped<IUserReadRepository, UserReadRepository>()
            .AddScoped<IUserWriteRepository, UserWriteRepository>();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>()
                       .AddScoped<IPasswordHasher, BCryptPasswordHasher>();

    }
}


