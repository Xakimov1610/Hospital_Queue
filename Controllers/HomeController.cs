using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospital_queue.Models;

namespace Hospital_queue.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AdminPage()
    {
        return View();
    }
    public IActionResult TakeQueue()
    {
        return View();
    }
    public IActionResult ShowQueue()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
