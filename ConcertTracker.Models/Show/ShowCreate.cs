using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Show;

public class ShowCreate
{
    [Required]
    public int BandId {get; set;}

    [Required]
    public int VenueId {get; set;}

    [Required]
    public string Date {get; set;} = null!;
}