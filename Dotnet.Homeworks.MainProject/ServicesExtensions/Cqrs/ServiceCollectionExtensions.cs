using Dotnet.Homeworks.DataAccess.Extensions;
using Dotnet.Homeworks.Features.Helpers;
using Dotnet.Homeworks.Infrastructure.Extensions;

namespace Dotnet.Homeworks.MainProject.ServicesExtensions.Cqrs;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        return services
            .AddDataAccess()
            .AddInfrastructure()
            .AddMediatR(conf => conf.RegisterServicesFromAssembly(AssemblyReference.Assembly));
    }
}