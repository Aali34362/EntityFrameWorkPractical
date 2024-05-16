using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;

namespace EntityFrameworkCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachesController : ControllerBase
{
    private readonly FootballLeagueApiDBContext _context;

    public CoachesController(FootballLeagueApiDBContext context)
    {
        _context = context;
    }

    // GET: api/Coaches
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Coach>>> Getcoaches()
    {
        return await _context.coaches.ToListAsync();
    }

    // GET: api/Coaches/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Coach>> GetCoach(Guid id)
    {
        var coach = await _context.coaches.FindAsync(id);

        if (coach == null)
        {
            return NotFound();
        }

        return coach;
    }

    // PUT: api/Coaches/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCoach(Guid id, Coach coach)
    {
        if (id != coach.Id)
        {
            return BadRequest();
        }

        _context.Entry(coach).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CoachExists(id))
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

    // POST: api/Coaches
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Coach>> PostCoach(Coach coach)
    {
        _context.coaches.Add(coach);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCoach", new { id = coach.Id }, coach);
    }

    // DELETE: api/Coaches/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoach(Guid id)
    {
        var coach = await _context.coaches.FindAsync(id);
        if (coach == null)
        {
            return NotFound();
        }

        _context.coaches.Remove(coach);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CoachExists(Guid id)
    {
        return _context.coaches.Any(e => e.Id == id);
    }
}
