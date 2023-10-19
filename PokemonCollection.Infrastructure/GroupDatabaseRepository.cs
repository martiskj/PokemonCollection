using Microsoft.EntityFrameworkCore;
using PokemonCollection.Application.Favorites;

namespace PokemonCollection.Infrastructure;

internal class GroupDatabaseRepository : IGroupRepository
{
    private readonly ApplicationDbContext _database;

    public GroupDatabaseRepository(ApplicationDbContext database)
    {
        _database = database;
    }

    public async Task<GroupId> Create(string name)
    {
        var group = _database.Groups
            .Add(new Group(name))
            .Entity;
        
        await _database.SaveChangesAsync();
        return group.Id;
    }

    public async Task<IEnumerable<Group>> GetAll(int skip, int take)
    {
        return await _database.Groups
            .Include(g => g.Favorites)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Group?> GetById(GroupId id)
    {
        return await _database.Groups
            .Include(g => g.Favorites)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Group group)
    {
        await _database.SaveChangesAsync();
    }
}
