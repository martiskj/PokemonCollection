namespace PokemonCollection.Application.Favorites;

public record FavoriteId(Guid Value);

public class Favorite
{
    public Favorite() { }

    public Favorite(Pokemon pokemon, int order)
    {
        Id = new FavoriteId(Guid.NewGuid());
        Pokemon = pokemon;
        Order = order;
    }

    public FavoriteId Id { get; private set; }

    public Pokemon Pokemon { get; private set; }

    public int Order { get; internal set; }
}
