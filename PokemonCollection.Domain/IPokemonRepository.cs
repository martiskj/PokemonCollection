namespace PokemonCollection.Application.Favorites;

public interface IPokemonRepository
{
    Task<Pokemon?> GetById(PokemonId pokemonId);
}
