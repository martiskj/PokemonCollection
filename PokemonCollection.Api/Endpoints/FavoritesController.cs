using Microsoft.AspNetCore.Mvc;
using PokemonCollection.Api.Contracts;
using PokemonCollection.Application.Favorites;

namespace PokemonCollection.Api.Endpoints;

[ApiController]
public class FavoritesController : ControllerBase
{
    [HttpPost("v1/groups/{groupId:guid}/favorites")]
    public async Task<ActionResult> CreateFavorite(
        [FromServices] FavoriteHandler handler,
        [FromRoute] Guid groupId,
        [FromBody] CreateFavoriteRequest request)
    {
        var command = new CreateFavoriteCommand(
                        new PokemonId(request.PokemonId),
                        new GroupId(groupId));
        
        var favorite = await handler.CreateFavorite(command);
        return Created(string.Empty, new
        {
            Id = favorite.Value
        });
    }

    [HttpDelete("v1/groups/{groupId:guid}/favorites/{pokemonId:int}")]
    public async Task<ActionResult> DeleteFavorite(
        [FromServices] FavoriteHandler handler,
        [FromRoute] Guid groupId,
        [FromRoute] int pokemonId)
    {
        var command = new DeleteFavoriteCommand(
            new PokemonId(pokemonId),
            new GroupId(groupId));
        
        await handler.DeleteFavorite(command);
        return NoContent();
    }
}

