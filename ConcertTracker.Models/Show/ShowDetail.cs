using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Show;

public class ShowDetail
{
    public int Id {get; set;}

    [Display(Name = "Band Id")]
    public int BandId {get; set;}

    [Display(Name = "Venue Id")]
    public int VenueId {get; set;}

    public DateTime Date {get; set;}
}