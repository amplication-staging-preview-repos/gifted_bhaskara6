using YomKippurSynagoguePlacement.APIs;

namespace YomKippurSynagoguePlacement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICongregantsService, CongregantsService>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IReservationsService, ReservationsService>();
        services.AddScoped<ISynagoguesService, SynagoguesService>();
    }
}
