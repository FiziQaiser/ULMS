using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ULMS.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ULMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PastpapersController : ControllerBase
{
    private readonly PostgresContext _context;

    public PastpapersController(PostgresContext context)
    {
        _context = context;
    }

    // GET: api/Pastpapers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pastpaper>>> GetPastpapers()
    {
        return await _context.Pastpapers.ToListAsync();
    }

    // GET: api/Pastpapers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pastpaper>> GetPastpaper(long id)
    {
        var pastpaper = await _context.Pastpapers.FindAsync(id);

        if (pastpaper == null)
        {
            return NotFound();
        }

        return pastpaper;
    }

    // GET: api/Pastpapers/Course/5
    [HttpGet("Course/{courseId}")]
    public async Task<ActionResult<IEnumerable<Pastpaper>>> GetPastpapersByCourseId(long courseId)
    {
        var pastpapers = await _context.Pastpapers
                            .Where(pp => pp.CourseId == courseId)
                            .ToListAsync();

        if (!pastpapers.Any())
        {
            return NotFound();
        }

        return pastpapers;
    }

    // POST: api/Pastpapers
    [HttpPost]
    public async Task<ActionResult<Pastpaper>> PostPastpaper(Pastpaper pastpaper)
    {
        _context.Pastpapers.Add(pastpaper);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPastpaper), new { id = pastpaper.Id }, pastpaper);
    }

    // PUT: api/Pastpapers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPastpaper(long id, Pastpaper pastpaper)
    {
        if (id != pastpaper.Id)
        {
            return BadRequest();
        }

        _context.Entry(pastpaper).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PastpaperExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Pastpapers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePastpaper(long id)
    {
        var pastpaper = await _context.Pastpapers.FindAsync(id);
        if (pastpaper == null)
        {
            return NotFound();
        }

        _context.Pastpapers.Remove(pastpaper);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PastpaperExists(long id)
    {
        return _context.Pastpapers.Any(e => e.Id == id);
    }
}
