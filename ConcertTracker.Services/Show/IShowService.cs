using ConcertTracker.Models.Show;

namespace ConcertTracker.Services.Show;

public interface IShowService
{
    Task<List<ShowListItem>> GetAllShowsAsync();
    Task<bool> CreateShowAsync(ShowCreate model);
}