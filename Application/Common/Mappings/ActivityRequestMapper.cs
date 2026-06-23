using Domain;
using Application.Activities.Requests;

public sealed class ActivityRequestMapper : IMapper<ActivityRequest, Activity>
{
    public void Map(ActivityRequest source, Activity destination)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(destination);

        destination.Title       = source.Title;
        destination.Date        = source.Date;
        destination.Description = source.Description;
        destination.Category    = source.Category;
        destination.City        = source.City;
        destination.Venue       = source.Venue;
        destination.Latitude    = source.Latitude;
        destination.Longitude   = source.Longitude;
    }

    public Activity Map(ActivityRequest source)
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
}
