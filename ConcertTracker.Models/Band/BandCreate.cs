using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Band;

public class BandCreate 
{
    [Required]
    [StringLength(100)]
    public string Name {get; set;} = string.Empty;
    [Required]
    [StringLength(50)]
    public string Genre {get; set;} = string.Empty;
}