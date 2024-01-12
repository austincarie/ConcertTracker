using ConcertTracker.Data;
using ConcertTracker.Data.Entities;
using ConcertTracker.Models.Band;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<bool> UpdateBandAsync(BandEdit model)
    {
        BandEntity? entity = await _context.Bands.FindAsync(model.Id);

        if (entity is null)
            return false;

        entity.Name = model.Name;
        entity.Genre = model.Genre;
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteBandAsync(int id)
    {
        BandEntity? entity = await _context.Bands.FindAsync(id);
        if (entity is null)
            return false;

        _context.Bands.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    
    public async Task<IEnumerable<SelectListItem>> BandSelectList()
    {
        IEnumerable<SelectListItem> bandList = _context.Bands
            .Select(b => new SelectListItem()
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                });
        return bandList;

    }
    
}