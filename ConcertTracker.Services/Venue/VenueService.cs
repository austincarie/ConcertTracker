using ConcertTracker.Data;
using ConcertTracker.Data.Entities;
using ConcertTracker.Models.Venue;
using Microsoft.EntityFrameworkCore;

namespace ConcertTracker.Services.Venue;

public class VenueService : IVenueService
{
    private ApplicationDbContext _context;
    public VenueService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VenueListItem>> GetAllVenuesAsync()
    {
        List<VenueListItem> venues = await _context.Venues
            .Select(v => new VenueListItem()
            {
                Id = v.Id,
                Name = v.Name
            })
            .ToListAsync();

        return venues;
    }

    public async Task<bool> CreateVenueAsync(VenueCreate model)
    {
        VenueEntity entity = new()
        {
            Name = model.Name,
            Location = model.Location
        };
        _context.Venues.Add(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<VenueDetail?> GetVenueAsync(int id)
    {
        VenueEntity? venue = await _context.Venues
            .FirstOrDefaultAsync(v => v.Id == id);
        
        return venue is null ? null : new()
        {
            Id = venue.Id,
            Name = venue.Name,
            Location = venue.Location
        };
    }

    public async Task<bool> UpdateVenueAsync(VenueEdit model)
    {
        VenueEntity? entity = await _context.Venues.FindAsync(model.Id);

        if (entity is null)
            return false;

        entity.Name = model.Name;
        entity.Location = model.Location;
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteVenueAsync(int id)
    {
        VenueEntity? entity = await _context.Venues.FindAsync(id);
        if (entity is null)
            return false;

        var shows = await _context.Shows.Where(s => s.VenueId == entity.Id).ToListAsync();
        _context.Shows.RemoveRange(shows);
        await _context.SaveChangesAsync();

        _context.Venues.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<VenueList>> GetVenueListAsync()
    {
        List<VenueList> venueList = await _context.Venues
            .Select(v => new VenueList()
            {
                Id = v.Id,
                Name = v.Name
            })
            .ToListAsync();
        return venueList;
    }
}