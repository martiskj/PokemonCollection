namespace PokemonCollection.Api.Contracts;

public record CreateGroupRequest(
    string Name);

public record GroupRespons(
    Guid Id,
    string Name,
    IEnumerable<GroupedPokemonResponse> Pokemons);
