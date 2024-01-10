using ConcertTracker.Models.Venue;
using ConcertTracker.Services.Venue;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTracker.Mvc.Controllers;

public class VenueController : Controller
{
    private IVenueService _service;
    public VenueController(IVenueService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        List<VenueListItem> venues = (List<VenueListItem>)await _service.GetAllVenuesAsync();
        return View(venues);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(VenueCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateVenueAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        VenueDetail? model = await _service.GetVenueAsync(id);

        if (model is null)
            return NotFound();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        VenueDetail? venue = await _service.GetVenueAsync(id);
        if (venue is null)
            return NotFound();

        VenueEdit model = new()
        {
            Id = venue.Id,
            Name = venue.Name ?? "",
            Location = venue.Location ?? ""
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, VenueEdit model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        if (await _service.UpdateVenueAsync(model))
            return RedirectToAction(nameof(Details), new {id = id});
        
        ModelState.AddModelError("Save Error", "Could not update the Venue. Please try again.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        VenueDetail? venue = await _service.GetVenueAsync(id);
        if (venue is null)
            return RedirectToAction(nameof(Index));

        return View(venue);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        await _service.DeleteVenueAsync(id);
        return RedirectToAction(nameof(Index));
    }
}