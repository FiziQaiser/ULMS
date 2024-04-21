using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ULMS.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ULMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly PostgresContext _context;

        public SubmissionController(PostgresContext context)
        {
            _context = context;
        }

        // POST: api/Submission
        [HttpPost]
        public async Task<ActionResult<Submission>> PostSubmission(Submission submission)
        {
            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubmission), new { id = submission.SubmissionId }, submission);
        }

        // GET: api/Submission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Submission>> GetSubmission(long id)
        {
            var submission = await _context.Submissions.FindAsync(id);

            if (submission == null)
            {
                return NotFound();
            }

            return submission;
        }

        // GET: api/Submission/Post/5
        [HttpGet("Post/{postId}")]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissionsByPostId(long postId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.PostId == postId)
                .ToListAsync();

            if (!submissions.Any())
            {
                return NotFound();
            }

            return submissions;
        }

        // GET: api/Submission/Classroom/5
        [HttpGet("{classroomId}")]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissionsByClassroomId(long classroomId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.ClassroomId == classroomId)
                .ToListAsync();

            if (!submissions.Any())
            {
                return NotFound();
            }

            return submissions;
        }

        // GET: api/submission/{classroomId}/{postId}
        [HttpGet("{classroomId}/{postId}")]
        public async Task<ActionResult<IEnumerable<Submission>>> GetSubmissionByClassroomId(long classroomId, long postId)
        {
            var submissions = await _context.Submissions
                .Where(s => s.ClassroomId == classroomId && s.PostId == postId)
                .ToListAsync();

            if (!submissions.Any())
            {
                return NotFound();
            }

            return submissions;
        }
        
        // DELETE: api/Submission/{classroomId}/{postId}
        [HttpDelete("{classroomId}/{postId}")]
        public async Task<IActionResult> DeleteSubmissionByClassroomId(long classroomId, long postId)
        {
            try
            {
                // Retrieve submissions based on classroom ID and post ID
                var submissionsToDelete = await _context.Submissions
                    .Where(s => s.ClassroomId == classroomId && s.PostId == postId)
                    .ToListAsync();

                if (submissionsToDelete == null || submissionsToDelete.Count == 0)
                {
                    return NotFound();
                }

                // Remove submissions from the context and save changes
                _context.Submissions.RemoveRange(submissionsToDelete);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception if any
                return StatusCode(500, $"An error occurred while deleting submissions: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmission(long id, Submission submission)
        {
            if (id != submission.SubmissionId)
            {
                return BadRequest();
            }

            _context.Entry(submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(id))
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

        private bool SubmissionExists(long id)
        {
            return _context.Submissions.Any(e => e.SubmissionId == id);
        }


    }
}
