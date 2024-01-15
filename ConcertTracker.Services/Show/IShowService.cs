using ConcertTracker.Models.Show;

namespace ConcertTracker.Services.Show;

public interface IShowService
{
    Task<List<ShowListItem>> GetAllShowsAsync();
    Task<bool> CreateShowAsync(ShowCreate model);
    Task<ShowDetail?> GetShowAsync(int id);
    Task<bool> UpdateShowAsync(ShowEdit model);
    Task<bool> DeleteShowAsync(int id);
}