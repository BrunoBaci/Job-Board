using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _db;

    public JobsController(AppDbContext db) => _db = db;

    [HttpPost]
    public IActionResult CreateJob(Job job)
    {
        _db.Jobs.Add(job);
        _db.SaveChanges();
        return Ok(job);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJob(int id, Job job)
    {
        var existing = _db.Jobs.Find(id);
        if (existing == null) return NotFound();

        existing.Title = job.Title;
        existing.Description = job.Description;
        existing.Location = job.Location;
        existing.ExpirationDate = job.ExpirationDate;
        _db.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJob(int id)
    {
        var job = _db.Jobs.Find(id);
        if (job == null) return NotFound();
        _db.Jobs.Remove(job);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpGet("{id}/applications")]
    public IActionResult GetApplications(int id)
    {
        var apps = _db.Applications.Where(a => a.JobId == id).Include(a => a.User).ToList();
        return Ok(apps);
    }
}