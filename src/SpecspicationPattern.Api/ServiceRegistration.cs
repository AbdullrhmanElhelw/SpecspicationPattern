using MediatR;
using Microsoft.EntityFrameworkCore;
using SpecspicationPattern.Api.Data;
using SpecspicationPattern.Api.Data.Infrastructure;
using SpecspicationPattern.Api.Data.Interceptors;
using SpecspicationPattern.Api.Data.Repositories;
using SpecspicationPattern.Api.Models.Departments;
using SpecspicationPattern.Api.Utilities.Behaviors;
using System.Reflection;

namespace SpecspicationPattern.Api;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.DefaultConnection)
            ?? throw new ArgumentNullException(nameof(ConnectionString.DefaultConnection));

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<ApplicationDbContext>(
            (sp, options) => options
                .UseSqlServer(connectionString)
                .AddInterceptors(
                    sp.GetRequiredService<SoftDeleteInterceptor>()));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<SoftDeleteInterceptor>();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }
}