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

}

