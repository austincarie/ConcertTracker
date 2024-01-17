using ConcertTracker.Models.Show;
using ConcertTracker.Services.Band;
using ConcertTracker.Services.Show;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConcertTracker.Mvc.Controllers;

public class ShowController : Controller
{
    private IShowService _service;
    private IBandService _bandService;
    public ShowController(IShowService service, IBandService bandService)
    {
        _service = service;
        _bandService = bandService;
    }

    public async Task<IActionResult> Index()
    {
        List<ShowListItem> shows = await _service.GetAllShowsAsync();
        
        return View(shows);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.BandList = new SelectList(await _bandService.GetBandListAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShowCreate model)
    {
        ViewBag.BandList = new SelectList(await _bandService.GetBandListAsync(), "Id", "Name");
        
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateShowAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ShowDetail? model = await _service.GetShowAsync(id);

        if (model is null)
            return NotFound();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ViewBag.BandList = new SelectList(await _bandService.GetBandListAsync(), "Id", "Name");
        ShowDetail? show = await _service.GetShowAsync(id);
        if (show is null)
            return NotFound();

        ShowEdit model = new()
        {
            Id = show.Id,
            BandId = show.BandId,
            VenueId = show.VenueId,
            Date = show.Date
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ShowEdit model)
    {
        ViewBag.BandList = new SelectList(await _bandService.GetBandListAsync(), "Id", "Name");
        if (!ModelState.IsValid)
            return View(model);

        if (await _service.UpdateShowAsync(model))
            return RedirectToAction(nameof(Details), new {id = id});

        ModelState.AddModelError("Save Error", "Could not update the show. Please try again.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        ShowDetail? show = await _service.GetShowAsync(id);
        if (show is null)
            return RedirectToAction(nameof(Index));

        return View(show);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        await _service.DeleteShowAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
