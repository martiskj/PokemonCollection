using Microsoft.EntityFrameworkCore;
using PokemonCollection.Application.Favorites;

namespace PokemonCollection.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Favorite> Favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Group>()
            .HasKey(group => group.Id);

        modelBuilder
            .Entity<Group>()
            .Property(group => group.Id)
            .HasConversion(id => id.Value, value => new GroupId(value));

        modelBuilder
            .Entity<Group>().Metadata
            .FindNavigation(nameof(Group.Favorites))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        modelBuilder
            .Entity<Favorite>()
            .HasKey(pokemon => pokemon.Id);

        modelBuilder
            .Entity<Favorite>()
            .Property(pokemon => pokemon.Id)
            .HasConversion(id => id.Value, value => new FavoriteId(value));

        modelBuilder.Entity<Favorite>().OwnsOne(grouped => grouped.Pokemon, pokemon =>
        {
            pokemon
                .Property(p => p.Id)
                .HasColumnName("PokemonId")
                .HasConversion(id => id.Value, value => new PokemonId(value));

            pokemon
                .Property(p => p.Name)
                .HasColumnName("PokemonName");
        });

        base.OnModelCreating(modelBuilder);
    }
}