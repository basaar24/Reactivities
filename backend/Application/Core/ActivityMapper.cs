using Application.Activities.DTOs;
using Domain;

namespace Application.Core;

public class ActivityMapper : IActivityMapper
{
    public Activity ToDomain(CreateActivityDto createDto) => new()
    {
        Title = createDto.Title,
        Date = createDto.Date,
        Description = createDto.Description,
        Category = createDto.Category,
        City = createDto.City,
        Venue = createDto.Venue,
        Latitude = createDto.Latitude,
        Longitude = createDto.Longitude
    };

    public void ToDomain(UpdateActivityDto source, Activity destination)
    {
        destination.Id = source.Id;
        destination.Title = source.Title;
        destination.Date = source.Date;
        destination.Description = source.Description;
        destination.Category = source.Category;
        destination.City = source.City;
        destination.Venue = source.Venue;
        destination.Latitude = source.Latitude;
        destination.Longitude = source.Longitude;
    }

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
