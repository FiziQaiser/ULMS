using Microsoft.AspNetCore.Mvc;
using ULMS.Shared.Models;
using System.Linq;

namespace ULMS.Server.Controllers;
    
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly PostgresContext _context;

    public BookController(PostgresContext context)
    {
        _context = context;
    }

    // Existing GET method to retrieve books
    [HttpGet]
    public IActionResult Get()
    {
        var books = _context.Books.ToList();
        return Ok(books);
    }

    // New POST method to upload a book
    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        if (book == null)
        {
            return BadRequest("Book is null.");
        }

        // Add validation logic here if necessary (e.g., check if the book already exists)

        _context.Books.Add(book); // Add the book to the DbSet<Book>
        _context.SaveChanges(); // Save changes to the database

        return CreatedAtAction(nameof(Get), new { id = book.Id }, book); // Return a response
    }
}