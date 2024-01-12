namespace ConcertTracker.Models.Show;

public class ShowListItem
{
    public int Id {get; set;}
    public int BandId {get; set;}

    public int VenueId {get; set;}

    public DateTime Date {get; set;}
}