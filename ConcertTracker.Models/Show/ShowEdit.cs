using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Show;

public class ShowEdit
{
    public int Id {get; set;}
    
    [Required]
    public int BandId {get; set;}

    [Required]
    public int VenueId {get; set;}

    [Required]
    public DateTime Date {get; set;}
}