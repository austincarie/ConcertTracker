using ConcertTracker.Models.Band;

namespace ConcertTracker.Services.Band;

public interface IBandService
{
    Task<IEnumerable<BandListItem>> GetAllBandsAsync();
    Task<bool> CreateBandAsync(BandCreate model);
    Task<BandDetail?> GetBandAsync(int id);
    Task<bool> UpdateBandAsync(BandEdit model);
}