using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Data.Entities;

public class BandEntity
{
    [Key]
    public int Id {get; set;}
    [Required, MaxLength(100)]
    public string Name {get; set;} = string.Empty;
    [Required, MaxLength(50)]
    public string Genre {get; set;} = string.Empty;

}