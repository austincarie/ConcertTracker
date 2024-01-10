using ConcertTracker.Models.Show;

namespace ConcertTracker.Services.Show;

public interface IShowService
{
    Task<bool> CreateShowAsync(ShowCreate model);
}