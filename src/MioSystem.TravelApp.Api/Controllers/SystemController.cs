using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MioSystem.TravelApp.Infrastructure.Data;

namespace MioSystem.TravelApp.Api.Controllers;

[ApiController]
[Route("api/system")]
public class SystemController : ControllerBase
{
    private readonly TravelAppDbContext _db;

    public SystemController(TravelAppDbContext db)
    {
        _db = db;
    }

    [HttpGet("health-db")]
    public async Task<IActionResult> HealthDb()
    {
        var canConnect = await _db.Database.CanConnectAsync();

        return Ok(new
        {
            database = "MioSystemTravelAppDb",
            canConnect,
            serverTime = DateTime.Now
        });
    }
}