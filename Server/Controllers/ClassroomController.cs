using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ULMS.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ULMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomController : ControllerBase
{
    private readonly PostgresContext _context;

    public ClassroomController(PostgresContext context)
    {
        _context = context;
    }

    // GET: api/Classroom
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
    {
        return await _context.Classrooms.ToListAsync();
    }

    // GET: api/Classroom/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Classroom>> GetClassroom(long id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);

        if (classroom == null)
        {
            return NotFound();
        }

        return classroom;
    }

    // GET: api/Classroom/User/5
    [HttpGet("User/{userId}")]
    public async Task<ActionResult<IEnumerable<Classroom>>> GetClassroomsByUserId(long userId)
    {
        var classrooms = await _context.Classrooms
                            .Where(c => c.UserId == userId)
                            .ToListAsync();

        if (!classrooms.Any())
        {
            return NotFound();
        }

        return classrooms;
    }

    // POST: api/Classroom
    [HttpPost]
    public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
    {
        _context.Classrooms.Add(classroom);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClassroom), new { id = classroom.ClassroomId }, classroom);
    }

    // PUT: api/Classroom/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClassroom(long id, Classroom classroom)
    {
        if (id != classroom.ClassroomId)
        {
            return BadRequest();
        }

        _context.Entry(classroom).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClassroomExists(id))
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

    // DELETE: api/Classroom/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClassroom(long id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }

        _context.Classrooms.Remove(classroom);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    // GET: api/Classroom/Users/{classroomId}
    [HttpGet("Users/{classroomId}")]
    public async Task<ActionResult<IEnumerable<long>>> GetUserIdsByClassroomId(long classroomId)
    {
        var userIds = await _context.Classrooms
            .Where(c => c.ClassroomId == classroomId)
            .Select(c => c.UserId)
            .ToListAsync();
    
        if (!userIds.Any())
        {
            return NotFound();
        }
    
        return userIds;
    }


    private bool ClassroomExists(long id)
    {
        return _context.Classrooms.Any(e => e.ClassroomId == id);
    }
    
// GET: api/Classroom/Users/{classroomId}
    // [HttpGet("Users/{classroomId}")]
    // public async Task<ActionResult<IEnumerable<(long UserId, string UserName)>>> GetUsersByClassroomId(long classroomId)
    // {
    //     var classroom = await _context.Classrooms.FindAsync(classroomId);
    //     if (classroom == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     var users = await _context.Accounts
    //         .Where(a => _context.Classrooms.Any(c => c.ClassroomId == classroomId && c.UserId == a.Id))
    //         .Select(a => new { UserId = a.Id, UserName = a.Name })
    //         .ToListAsync();
    //
    //     if (users.Any())
    //     {
    //         var userDetails = users.Select(u => (UserId: u.UserId, UserName: u.UserName)).ToList();
    //         return userDetails;
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }
    // }



}
