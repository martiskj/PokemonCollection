using PokemonCollection.Application.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCollection.Infrastructure;

internal record PokemonDto(int id, string name);

internal class PokemonHttpRepository : IPokemonRepository
{

    private readonly HttpClient _http;

    public PokemonHttpRepository(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://pokeapi.co/");
    }

    public async Task<Pokemon?> GetById(PokemonId pokemonId)
    {
        var response = await _http.GetAsync($"api/v2/pokemon/{pokemonId.Value}");
        
        if (response.StatusCode is System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        var dto = await response.Content.ReadFromJsonAsync<PokemonDto>();
        if (dto is null)
        {
            return null;
        }

        return new Pokemon(new PokemonId(dto.id), dto.name);
    }
}
