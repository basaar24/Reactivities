/// <summary>
/// Defines a two-way mapping contract between
/// <typeparamref name="TSource"/> and <typeparamref name="TDestination"/>.
/// </summary>
public interface IMapper<TSource, TDestination>
{
    /// <summary>Maps all properties from <paramref name="source"/> into <paramref name="destination"/>.</summary>
    void Map(TSource source, TDestination destination);
 
    /// <summary>Convenience overload – creates a new destination instance and maps into it.</summary>
    TDestination Map(TSource source);
}