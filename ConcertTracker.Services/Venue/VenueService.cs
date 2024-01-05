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
}