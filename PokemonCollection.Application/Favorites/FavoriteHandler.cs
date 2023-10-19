namespace PokemonCollection.Application.Favorites;

public record CreateFavoriteCommand(PokemonId PokemonId, GroupId GroupId);

public record DeleteFavoriteCommand(PokemonId PokemonId, GroupId GroupId);

public class FavoriteHandler
{
    private readonly IPokemonRepository _pokemons;
    private readonly IGroupRepository _groups;

    public FavoriteHandler(IPokemonRepository pokemons, IGroupRepository favorites)
    {
        _pokemons = pokemons;
        _groups = favorites;
    }

    public async Task<FavoriteId> CreateFavorite(CreateFavoriteCommand command)
    {
        var pokemon = await _pokemons.GetById(command.PokemonId);
        if (pokemon is null)
        {
            throw new PokemonNotFoundException(command.PokemonId);
        }

        var group = await _groups.GetById(command.GroupId);
        if (group is null)
        {
            throw new GroupNotFoundException(command.GroupId);
        }

        var favoriteId = group.Add(pokemon);
        await _groups.Update(group);

        return favoriteId;
    }

    public async Task DeleteFavorite(DeleteFavoriteCommand command)
    {
        var group = await _groups.GetById(command.GroupId);
        if (group is null)
        {
            throw new GroupNotFoundException(command.GroupId);
        }

        group.Delete(command.PokemonId);
        await _groups.Update(group);
    }
}
