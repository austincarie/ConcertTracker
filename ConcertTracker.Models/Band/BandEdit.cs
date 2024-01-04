using System.ComponentModel.DataAnnotations;

namespace ConcertTracker.Models.Band;

public class BandEdit 
{
    [Required]
    public int Id {get; set;}

    [Required, StringLength(100)]
    public string Name {get; set;} = string.Empty;

    [Required, StringLength(50)]
    public string Genre {get; set;} = string.Empty;
}