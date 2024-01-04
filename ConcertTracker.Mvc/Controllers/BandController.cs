using ConcertTracker.Models.Band;
using ConcertTracker.Services.Band;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTracker.Mvc.Controllers;

public class BandController : Controller
{
    private IBandService _service;
    public BandController(IBandService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        List<BandListItem> bands = (List<BandListItem>)await _service.GetAllBandsAsync();
        return View(bands);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BandCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateBandAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        BandDetail? model = await _service.GetBandAsync(id);

        if (model is null)
            return NotFound();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        BandDetail? band = await _service.GetBandAsync(id);
        if (band is null)
            return NotFound();

        BandEdit model = new()
        {
            Id = band.Id,
            Name = band.Name ?? "",
            Genre = band.Genre ?? ""
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, BandEdit model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        if (await _service.UpdateBandAsync(model))
            return RedirectToAction(nameof(Details), new {id = id});
        
        ModelState.AddModelError("Save Error", "Could not update the Band. Please try again.");
        return View(model);
    }
}