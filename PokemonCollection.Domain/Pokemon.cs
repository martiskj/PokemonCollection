namespace PokemonCollection.Application.Favorites;

public class Pokemon
{
    public Pokemon(PokemonId id, string name)
    {
        Id = id;
        Name = name;
    }

    public PokemonId Id { get; init; }
    
    public string Name { get; init; }
}

public record PokemonId(int Value);
