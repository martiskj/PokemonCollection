namespace PokemonCollection.Application.Favorites;

public interface IGroupRepository
{
    Task<Group?> GetById(GroupId id);

    Task Update(Group group);

    Task<GroupId> Create(string name);
    
    Task<IEnumerable<Group>> GetAll(int skip, int take);
}
