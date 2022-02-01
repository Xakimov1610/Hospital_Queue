
using Hospital_queue.Data;
using Hospital_queue.Entities;
using Hospital_queue.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_queue.Controllers;
[Route("[controller]")]

public class QueueController : Controller
{
    private readonly QueueDbContext _context;
    private readonly ILogger<QueueController> _logger;

    public QueueController(QueueDbContext context, ILogger<QueueController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Create()
        => View();

    [HttpPost]
    public async Task<IActionResult> Create(QueueViewModel model)
    {
        var entity = new Queue(fullname: model.Fullname, phoneNumber: model.PhoneNumber);
        entity.Number = (ulong)_context.Queues.Count() + 1;
        var temp = _context.Queues.FirstOrDefault(q => q.Number == entity.Number - 1);
        entity.ServiceTime = entity.CreatedAt;
        if(temp is not null)
        {
            entity.ServiceTime.AddHours(1);
        }
        else entity.ServiceTime.AddMinutes(50);

        try
        {
            await _context.Queues.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return BadRequest("Creating queue is failed...");
        }
        return LocalRedirect($"/queue/{entity.Id}");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid Id)
        => View(await _context.Queues.FirstOrDefaultAsync(q => q.Id == Id));
}