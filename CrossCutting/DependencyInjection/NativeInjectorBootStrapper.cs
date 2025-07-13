using Domain.Repositories;
using Domain.Services;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace CrossCutting.DependencyInjection;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(
            op => op.UseNpgsql(configuration["ConnectionStrings:WebApiDatabase"]));

        services.AddScoped<ITravelRouteService, TravelRouteService>();
        services.AddScoped<ITravelRouteRepository, TravelRouteRepository>();

    }
}
