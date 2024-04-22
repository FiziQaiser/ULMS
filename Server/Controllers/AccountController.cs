using Microsoft.AspNetCore.Mvc;
using ULMS.Shared.Models;

namespace ULMS.Server.Controllers;
    
[ApiController]
[Route("")]
public class AccountController : ControllerBase
{
    private readonly PostgresContext _context;

    public AccountController(PostgresContext context)
    {
        _context = context;
    }

    [HttpGet("/account/validate")]
    public IActionResult Get(string email, string password)
    {
        // Check if email and password are provided
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            return BadRequest("Email and password are required.");
        }

        // Search for a user with the provided email and password
        var user = _context.Accounts.FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            // Return true if user is found
            return Ok(user);
        }
        else
        {
            // Return false if user is not found
            return Ok(user);
        }
        
    }
// GET: /account/{id}
    [HttpGet("/account/{id}")]
    public IActionResult GetById(long id)
    {
        var user = _context.Accounts.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            return Ok(user);
        }
        else
        {
            return NotFound();
        }
    }
    // GET: /account/students
    [HttpGet("/account/students")]
    public IActionResult GetStudents()
    {
        var students = _context.Accounts.Where(a => a.Role == "Student").ToList();
        if (students.Any())
        {
            return Ok(students);
        }
        else
        {
            return NotFound("No students found.");
        }
    }
    
    // GET: /account/students
    [HttpGet("/account/instructors")]
    public IActionResult GetInstructors()
    {
        var instructors = _context.Accounts.Where(a => a.Role == "Instructor").ToList();
        if (instructors.Any())
        {
            return Ok(instructors);
        }
        else
        {
            return NotFound("No instructors found.");
        }
    }
    [HttpPost("/account")]
    public IActionResult AddAccount([FromBody] Account account)
    {
        if (account == null)
        {
            return BadRequest("Account data is missing.");
        }

        if (string.IsNullOrWhiteSpace(account.Email) || string.IsNullOrWhiteSpace(account.Password))
        {
            return BadRequest("Account email and password are required.");
        }

        try
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while adding the account: {ex.Message}");
        }
    }

}

