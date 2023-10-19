using PokemonCollection.Application.Favorites;

namespace PokemonCollection.UnitTests;

public class GroupTests
{
    [Fact]
    public void Should_Be_Able_To_Add_Pokemons()
    {
        var group = new Group("Epic collection of pokemons");
        group.Add(new Pokemon(new PokemonId(1), "Bulbusaur"));
        group.Add(new Pokemon(new PokemonId(2), "Venusaur"));

        Assert.Equal(2, group.Favorites.Count);
    }

    [Fact]
    public void Should_Not_Be_Able_To_Add_Duplicate_Pokemons()
    {
        var group = new Group("Epic collection of pokemons");
        group.Add(new Pokemon(new PokemonId(1), "Bulbusaur"));

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            group.Add(new Pokemon(new PokemonId(1), "Bulbusaur"));
        });

        Assert.Equal("Pokemon already exists in group", exception.Message);
    }

    [Fact]
    public void Should_Not_Be_Able_To_Add_More_Than_Five_Pokemons()
    {
        var group = new Group("Epic collection of pokemons");
        group.Add(new Pokemon(new PokemonId(1), "Bulbusaur"));
        group.Add(new Pokemon(new PokemonId(2), "Venusaur"));
        group.Add(new Pokemon(new PokemonId(3), "Charmander"));
        group.Add(new Pokemon(new PokemonId(4), "Pikachu"));
        group.Add(new Pokemon(new PokemonId(5), "Mewtwo"));

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            group.Add(new Pokemon(new PokemonId(6), "Ditto"));
        });

        Assert.Equal("You can not have more than five pokemons in a group", exception.Message);
    }

    [Fact]
    public void When_Deleting_Pokemon_The_Remaining_Should_Reorder()
    {
        var group = new Group("Epic collection of pokemons");
        group.Add(new Pokemon(new PokemonId(1), "Bulbusaur"));
        group.Add(new Pokemon(new PokemonId(2), "Venusaur"));
        group.Add(new Pokemon(new PokemonId(3), "Charmander"));
        group.Add(new Pokemon(new PokemonId(4), "Pikachu"));

        Assert.Equal(1, group.Favorites.Single(x => x.Pokemon.Name is "Bulbusaur").Order);
        Assert.Equal(2, group.Favorites.Single(x => x.Pokemon.Name is "Venusaur").Order);
        Assert.Equal(3, group.Favorites.Single(x => x.Pokemon.Name is "Charmander").Order);
        Assert.Equal(4, group.Favorites.Single(x => x.Pokemon.Name is "Pikachu").Order);

        group.Delete(new PokemonId(2));

        Assert.Equal(1, group.Favorites.Single(x => x.Pokemon.Name is "Bulbusaur").Order);
        Assert.Equal(2, group.Favorites.Single(x => x.Pokemon.Name is "Charmander").Order);
        Assert.Equal(3, group.Favorites.Single(x => x.Pokemon.Name is "Pikachu").Order);
    }
}