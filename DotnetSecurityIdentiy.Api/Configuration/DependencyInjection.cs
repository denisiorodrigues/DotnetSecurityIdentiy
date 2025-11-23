namespace DotnetSecurityIdentiy.Api.Configuration;

public static class DependencyInjection
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<DotnetSecurityIdentiy.Api.Services.UserServie>();
    }
}
