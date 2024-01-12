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
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShowCreate model)
    {
        //var bandSelectList = new SelectList(await _bandService.BandSelectList(), "Name", "Id");
        //ViewBag.bandList = bandSelectList;
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateShowAsync(model);
        return RedirectToAction(nameof(Index));
    }
}
