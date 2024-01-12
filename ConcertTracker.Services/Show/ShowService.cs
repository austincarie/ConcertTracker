using ConcertTracker.Data;
using ConcertTracker.Data.Entities;
using ConcertTracker.Models.Band;
using ConcertTracker.Models.Show;
using Microsoft.EntityFrameworkCore;

namespace ConcertTracker.Services.Show;

public class ShowService : IShowService
{
    private ApplicationDbContext _context;
    public ShowService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ShowListItem>> GetAllShowsAsync()
    {
        List<ShowListItem> shows = await _context.Shows
            .Select(s => new ShowListItem()
            {
                Id = s.Id,
                BandId = s.BandId,
                VenueId = s.VenueId,
                Date = s.Date
            })
            .ToListAsync();

        return shows;
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