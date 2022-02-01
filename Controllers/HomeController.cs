using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospital_queue.Models;
using Hospital_queue.Data;

namespace Hospital_queue.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QueueDbContext _context;

    public HomeController(ILogger<HomeController> logger, QueueDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var queues = _context.Queues.ToList();
        return View(queues);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
