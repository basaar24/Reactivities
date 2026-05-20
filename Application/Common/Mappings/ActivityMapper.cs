using Domain;

/// <summary>
/// Maps one <see cref="Activity"/> onto another without any third-party library.
/// Follows the Open/Closed principle: add new properties here and nowhere else.
/// </summary>
public sealed class ActivityMapper : IMapper<Activity, Activity>
{
    // Optional list of property names to skip during mapping.
    private readonly HashSet<string> _ignoredProperties;

    // Parameterless constructor for DI
    public ActivityMapper() 
    {
        _ignoredProperties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }

    // Optional: keep this for manual use with ignored properties
    public ActivityMapper(params string[] ignoredProperties)
    {
        _ignoredProperties = new HashSet<string>(
            ignoredProperties,
            StringComparer.OrdinalIgnoreCase);
    }

    public void Map(Activity source, Activity destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);
 
        if (!Ignore(nameof(Activity.Id)))           destination.Id          = source.Id;
        if (!Ignore(nameof(Activity.Title)))        destination.Title       = source.Title;
        if (!Ignore(nameof(Activity.Date)))         destination.Date        = source.Date;
        if (!Ignore(nameof(Activity.Description)))  destination.Description = source.Description;
        if (!Ignore(nameof(Activity.Category)))     destination.Category    = source.Category;
        if (!Ignore(nameof(Activity.IsCancelled)))  destination.IsCancelled = source.IsCancelled;
        if (!Ignore(nameof(Activity.City)))         destination.City        = source.City;
        if (!Ignore(nameof(Activity.Venue)))        destination.Venue       = source.Venue;
        if (!Ignore(nameof(Activity.Latitude)))     destination.Latitude    = source.Latitude;
        if (!Ignore(nameof(Activity.Longitude)))    destination.Longitude   = source.Longitude;
    }
 
    public Activity Map(Activity source)
    {
        var destination = new Activity
        {
            Title       = source.Title,
            Description = source.Description,
            Category    = source.Category,
            City        = source.City,
            Venue       = source.Venue,
        };
 
        Map(source, destination);
        return destination;
    }
 
    private bool Ignore(string propertyName) =>
        _ignoredProperties.Contains(propertyName);
}