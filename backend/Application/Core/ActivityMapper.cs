using Application.Activities.Requests;
using Domain;

namespace Application.Core;

public class ActivityMapper : IActivityMapper
{
    public Activity ToActivity(CreateActivityRequest request) => new()
    {
        Title = request.Title,
        Date = request.Date,
        Description = request.Description,
        Category = request.Category,
        City = request.City,
        Venue = request.Venue,
        Latitude = request.Latitude,
        Longitude = request.Longitude
    };

    public void UpdateActivity(Activity source, Activity destination)
    {
        destination.Title = source.Title;
        destination.Date = source.Date;
        destination.Description = source.Description;
        destination.Category = source.Category;
        destination.IsCancelled = source.IsCancelled;
        destination.City = source.City;
        destination.Venue = source.Venue;
        destination.Latitude = source.Latitude;
        destination.Longitude = source.Longitude;
    }
}
