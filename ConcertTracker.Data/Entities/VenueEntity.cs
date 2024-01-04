using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Data.Entities;

public class VenueEntity
{
    [Key]
    public int id {get; set;}
    [Required]
    public string name {get; set;} = string.Empty;
    [Required]
    public string location {get; set;} = string.Empty;
    
}