using ConcertTracker.Models.Venue;

namespace ConcertTracker.Services.Venue;

public interface IVenueService
{
    Task<IEnumerable<VenueListItem>> GetAllVenuesAsync();
    Task<bool> CreateVenueAsync(VenueCreate model);
    Task<VenueDetail?> GetVenueAsync(int id);
}