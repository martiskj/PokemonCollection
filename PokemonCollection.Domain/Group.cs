namespace PokemonCollection.Application.Favorites;

public record GroupId(Guid Value);

public class Group
{
    private List<Favorite> _favorites = new List<Favorite>();

    public Group(string name)
    {
        Name = name;
        Id = new GroupId(Guid.NewGuid());
    }

    public GroupId Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<Favorite> Favorites => _favorites;

    public FavoriteId Add(Pokemon pokemon)
    {
        if (_favorites.Count >= 5)
        {
            throw new ArgumentException("You can not have more than five pokemons in a group");
        }

        if (_favorites.Any(x => x.Pokemon.Id == pokemon.Id))
        {
            throw new ArgumentException("Pokemon already exists in group");
        }

        int order = _favorites.Any() ? _favorites.Max(x => x.Order) + 1 : 1;
        var favorite = new Favorite(pokemon, order);

        _favorites.Add(favorite);
        return favorite.Id;
    }

    public void Delete(PokemonId pokemonId)
    {
        var pokemon = _favorites.FirstOrDefault(x => x.Pokemon.Id == pokemonId);
        if (pokemon is null)
        {
            throw new ArgumentException($"Group {Id.Value} does not contain pokemon with id {pokemonId.Value}");
        }

        _favorites.Remove(pokemon);

        foreach (var entry in _favorites.Where(x => x.Order > pokemon.Order))
        {
            entry.Order--;
        }
    }
}
