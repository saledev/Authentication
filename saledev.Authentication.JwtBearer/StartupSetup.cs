using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace saledev.Authentication.JwtBearer
{
    public static class StartupSetup
    {
        public static IServiceCollection AddAuthenticationJwtBearer(this IServiceCollection services, IConfiguration config)
        {

            services.Configure<AuthenticationOptions>(config);
            services.Configure<AuthenticationOptions>(config.GetSection(AuthenticationOptions.SectionName));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISessionManager, SessionManager>();

            return services;
        }
    }
}


/*
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyLibraryService(
      this IServiceCollection services,
      IConfiguration namedConfigurationSection)
    {
        // Default library options are overridden
        // by bound configuration values.
        services.Configure<LibraryOptions>(namedConfigurationSection);

        // Register lib services here...
        // services.AddScoped<ILibraryService, DefaultLibraryService>();

        return services;
    }
}
*/