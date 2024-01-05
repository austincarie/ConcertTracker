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
}