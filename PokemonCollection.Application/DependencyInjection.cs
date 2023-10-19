using Microsoft.Extensions.DependencyInjection;
using PokemonCollection.Application.Favorites;
using PokemonCollection.Application.Groups;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<GroupHandler>();
        services.AddTransient<FavoriteHandler>();

        return services;
    }
}
