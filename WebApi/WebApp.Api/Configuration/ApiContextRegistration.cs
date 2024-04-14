using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Api.Configuration;

public static class ApiContextRegistration
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
    }
}
