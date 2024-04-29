using DistributionAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public AnswersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Answer>>> GetAnswers()
        {
            return Ok(await _context.Answers
                .Include(e => e.User)
                .Include(e => e.question) // Include the question using the navigation property
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            var existingUser = await _context.Users.FindAsync(answer.user_id);
            
            if (existingUser == null)
            {
                return BadRequest("Invalid user ID");
            }

            var existingQuestion = await _context.Questions.FindAsync(answer.question_id);
            if (existingQuestion == null)
            {
                return BadRequest("Invalid question ID");
            }

            answer.User = existingUser;
            answer.question = existingQuestion;

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswers", new { id = answer.answer_id }, answer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.answer_id)
            {
                return BadRequest();
            }

            var existingUser = await _context.Users.FindAsync(answer.user_id);
            if (existingUser == null)
            {
                return BadRequest("Invalid user ID");
            }

            var existingQuestion = await _context.Questions.FindAsync(answer.question_id);
            if (existingQuestion == null)
            {
                return BadRequest("Invalid question ID");
            }

            answer.User = existingUser;
            answer.question = existingQuestion;

            _context.Entry(answer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.answer_id == id);
        }
    }
}
