using ConcertTracker.Data;
using ConcertTracker.Data.Entities;
using ConcertTracker.Models.Show;

namespace ConcertTracker.Services.Show;

public class ShowService : IShowService
{
    private ApplicationDbContext _context;
    public ShowService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateShowAsync(ShowCreate model)
    {
        ShowEntity entity = new()
        {
            BandId = model.BandId,
            VenueId = model.VenueId,
            Date = model.Date
        };
        _context.Shows.Add(entity);
        return await _context.SaveChangesAsync() == 1;
    }
}