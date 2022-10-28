using upd8.Business.Interfaces;
using upd8.Business.Notificacoes;
using upd8.Business.Services;
using upd8.Data.context;
using upd8.Data.Repository;

namespace upd8.MVC.Configurations;

public static class DepedencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<Upd8DbContext>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteService, ClienteService>();


        services.AddScoped<INotificador, Notificador>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //services.AddScoped<IUser, AspNetUser>();

        return services;

    }
}
