
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketManagement.API.Middlewares;
using TicketManagement.API.Services;
using TicketManagement.Application.Common;
using TicketManagement.Application.SeedWorks;
using TicketManagement.Infrastructure;
using TicketManagement.Infrastructure.SeedWorks;
using UserManagement.Application.Domains.Users.Handlers;

namespace TicketManagement.API;

public class Program
{
    public static void Main(string[] args)
    {
        string Policy = "AllowAll";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options => options.AddPolicy(Policy, p => p.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()));

        builder.Services.AddDbContext<TicketManagementDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly)
        );

        builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                };
            });
        builder.Services.AddAuthorization();


        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
    
        builder.Services.AddRepositories();
        builder.Services.AddServices();

        builder.Services.AddControllers();
       
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Management API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Type **Bearer** followed by space and your JWT token.\n\nExample: `Bearer eyJhbGciOi...`"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapSwagger();
        }

        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<CurrentUserMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
