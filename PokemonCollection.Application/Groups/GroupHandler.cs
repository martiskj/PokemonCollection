using PokemonCollection.Application.Favorites;

namespace PokemonCollection.Application.Groups;

public record CreateGroupCommand(string Name);

public record GetGroupsQuery(int Skip, int Take);

public class GroupHandler
{
    private readonly IGroupRepository _groups;

    public GroupHandler(IGroupRepository favorites)
    {
        _groups = favorites;
    }

    public async Task<GroupId> CreateGroup(CreateGroupCommand command)
    {
        return await _groups.Create(command.Name);
    }

    public async Task<IEnumerable<Group>> GetGroups(GetGroupsQuery query)
    {
        return await _groups.GetAll(query.Skip, query.Take);
    }

    public async Task<Group?> GetGroupById(GroupId id)
    {
        return await _groups.GetById(id);
    }
}
