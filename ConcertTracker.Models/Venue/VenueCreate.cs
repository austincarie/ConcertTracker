using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Venue;

public class VenueCreate
{
    [Required, StringLength(100)]
    public string Name {get; set;} = string.Empty;
    [Required, StringLength(100)]
    public string Location {get; set;} = string.Empty;
}