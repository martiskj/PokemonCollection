using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonCollection.Application.Favorites;

namespace PokemonCollection.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IGroupRepository, GroupDatabaseRepository>();
        services.AddTransient<IPokemonRepository, PokemonHttpRepository>();

        services.AddHttpClient<PokemonHttpRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=pokemon;Persist Security Info=False;User ID=sa;Password=yourStrong(#)Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        });

        return services;
    }
}
