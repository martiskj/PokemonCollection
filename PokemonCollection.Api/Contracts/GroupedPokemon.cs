namespace PokemonCollection.Api.Contracts;

public record CreateFavoriteRequest(int PokemonId);

public record GroupedPokemonResponse(
    int Id,
    string Name,
    int Order);