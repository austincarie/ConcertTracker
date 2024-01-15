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

    public async Task<ShowDetail?> GetShowAsync(int id)
    {
        ShowEntity? show = await _context.Shows
            .FirstOrDefaultAsync(s => s.Id == id);

        return show is null ? null : new()
        {
            Id = show.Id,
            BandId = show.BandId,
            VenueId = show.VenueId,
            Date = show.Date
        };
    }

    public async Task<bool> UpdateShowAsync(ShowEdit model)
    {
        ShowEntity? entity = await _context.Shows.FindAsync(model.Id);

        if (entity is null)
            return false;

        entity.BandId = model.BandId;
        entity.VenueId = model.VenueId;
        return await _context.SaveChangesAsync() == 1;
    }

    
}