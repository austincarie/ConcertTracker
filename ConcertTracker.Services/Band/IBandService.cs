using ConcertTracker.Models.Band;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcertTracker.Services.Band;

public interface IBandService
{
    Task<IEnumerable<BandListItem>> GetAllBandsAsync();
    Task<bool> CreateBandAsync(BandCreate model);
    Task<BandDetail?> GetBandAsync(int id);
    Task<bool> UpdateBandAsync(BandEdit model);
    Task<bool> DeleteBandAsync(int id);
    Task<IEnumerable<SelectListItem>> BandSelectList();
}