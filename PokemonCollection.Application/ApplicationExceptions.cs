using PokemonCollection.Application.Favorites;
using System.Runtime.Serialization;

namespace PokemonCollection.Application;

public class PokemonNotFoundException : ResourceNotFoundException
{
    public PokemonNotFoundException(PokemonId id)
        : base($"Pokemon with id {id.Value} was not found") { }
}

public class GroupNotFoundException : ResourceNotFoundException
{
    public GroupNotFoundException(GroupId id)
        : base($"Group with id {id.Value} does not exist") { }
}

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException() { }

    public ResourceNotFoundException(string? message) : base(message) { }

    public ResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
