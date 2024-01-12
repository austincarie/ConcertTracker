using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcertTracker.Data.Entities;

public class ShowEntity
{
    [Key]
    public int Id {get; set;}
    
    [Required]
    [ForeignKey(nameof(Band))]
    public int BandId {get; set;}
    public virtual BandEntity Band {get; set;} = null!;

    [Required]
    [ForeignKey(nameof(Venue))]
    public int VenueId {get; set;}
    public virtual VenueEntity Venue {get; set;} = null!;

    [Required]
    public DateTime Date {get; set;}
}
//* id, band, venue, date
