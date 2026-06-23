using System.ComponentModel.DataAnnotations;

namespace Application.Activities.Requests;

public class CreateActivityRequest
{
    [Required]
    public string Title { get; set; } = "";
    public DateTime Date { get; set; }
    [Required]
    public string Description { get; set; } = "";
    [Required]
    public string Category { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    [Required]
    public string Venue { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
