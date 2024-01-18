using ConcertTracker.Models.Venue;

namespace ConcertTracker.Services.Venue;

public interface IVenueService
{
    Task<IEnumerable<VenueListItem>> GetAllVenuesAsync();
    Task<bool> CreateVenueAsync(VenueCreate model);
    Task<VenueDetail?> GetVenueAsync(int id);
    Task<bool> UpdateVenueAsync(VenueEdit model);
    Task<bool> DeleteVenueAsync(int id);
    Task<List<VenueList>> GetVenueListAsync();
}