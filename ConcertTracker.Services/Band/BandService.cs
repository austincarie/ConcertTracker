using ConcertTracker.Data;
using ConcertTracker.Data.Entities;
using ConcertTracker.Models.Band;
using Microsoft.EntityFrameworkCore;

namespace ConcertTracker.Services.Band;

public class BandService : IBandService
{
    private ApplicationDbContext _context;
    public BandService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<BandListItem>> GetAllBandsAsync()
    {
        List<BandListItem> bands = await _context.Bands
            .Select(b => new BandListItem()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();

        return bands;
    }
    
    public async Task<bool> CreateBandAsync(BandCreate model)
    {
        BandEntity entity = new()
        {
            Name = model.Name,
            Genre = model.Genre
        };
        _context.Bands.Add(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<BandDetail?> GetBandAsync(int id)
    {
        BandEntity? band = await _context.Bands
            .FirstOrDefaultAsync(b => b.Id == id);
        
        return band is null ? null : new()
        {
            Id = band.Id,
            Name = band.Name,
            Genre = band.Genre
        };
    }
}