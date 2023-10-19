using Microsoft.AspNetCore.Mvc;
using PokemonCollection.Api.Contracts;
using PokemonCollection.Application.Favorites;
using PokemonCollection.Application.Groups;

namespace PokemonCollection.Api.Endpoints;

[ApiController]
public class GroupController : ControllerBase
{
    [HttpPost("v1/groups")]
    public async Task<ActionResult> CreateGroup(
        [FromServices] GroupHandler handler,
        [FromBody] CreateGroupRequest request)
    {
        var command = new CreateGroupCommand(request.Name);
        var groupId = await handler.CreateGroup(command);
        
        return Created(string.Empty, new
        {
            Id = groupId.Value
        });
    }

    [HttpGet("v1/groups")]
    public async Task<ActionResult> GetGroups(
        [FromServices] GroupHandler handler,
        [FromQuery] int? skip = 0,
        [FromQuery] int? take = 20)
    {
        var query = new GetGroupsQuery(skip!.Value, take!.Value);
        var groups = await handler.GetGroups(query);

        return Ok(groups.Select(g => ToGroupResponse(g)));
    }

    [HttpGet("v1/groups/{groupId:guid}")]
    public async Task<ActionResult> GetGroupById(
    [FromServices] GroupHandler handler,
    [FromRoute] Guid groupId)
    {
        var group = await handler.GetGroupById(new GroupId(groupId));
        if (group is null)
        {
            return NotFound();
        }

        return Ok(ToGroupResponse(group));
    }

    private static GroupRespons ToGroupResponse(Group group)
    {
        return new GroupRespons(
            group.Id.Value,
            group.Name,
            group.Favorites
                .Select(x => new GroupedPokemonResponse(x.Pokemon.Id.Value, x.Pokemon.Name, x.Order))
                .OrderBy(x => x.Order));
    }
}
