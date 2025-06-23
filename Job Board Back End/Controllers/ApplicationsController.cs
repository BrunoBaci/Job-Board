using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Candidate")]
public class ApplicationsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ApplicationsController(AppDbContext db) => _db = db;

    [HttpPost("{jobId}/apply")]
    public IActionResult Apply(int jobId, [FromBody] ApplyRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var already = _db.Applications.Any(a => a.JobId == jobId && a.UserId == userId);
        if (already) return BadRequest("Already applied");

        var app = new Application { JobId = jobId, UserId = userId, Message = req.Message };
        _db.Applications.Add(app);
        _db.SaveChanges();
        return Ok(app);
    }

    [HttpGet("my-applications")]
    public IActionResult GetMyApps()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var apps = _db.Applications.Where(a => a.UserId == userId).Include(a => a.Job).ToList();
        return Ok(apps);
    }
}

public record ApplyRequest(string Message);