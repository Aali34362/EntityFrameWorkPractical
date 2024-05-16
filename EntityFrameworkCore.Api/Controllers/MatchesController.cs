using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;

namespace EntityFrameworkCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchesController : ControllerBase
{
    private readonly FootballLeagueApiDBContext _context;

    public MatchesController(FootballLeagueApiDBContext context)
    {
        _context = context;
    }

    // GET: api/Matches
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Match>>> Getmatches()
    {
        return await _context.matches.ToListAsync();
    }

    // GET: api/Matches/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Match>> GetMatch(Guid id)
    {
        var match = await _context.matches.FindAsync(id);

        if (match == null)
        {
            return NotFound();
        }

        return match;
    }

    // PUT: api/Matches/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMatch(Guid id, Match match)
    {
        if (id != match.Id)
        {
            return BadRequest();
        }

        _context.Entry(match).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MatchExists(id))
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

    // POST: api/Matches
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Match>> PostMatch(Match match)
    {
        _context.matches.Add(match);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMatch", new { id = match.Id }, match);
    }

    // DELETE: api/Matches/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMatch(Guid id)
    {
        var match = await _context.matches.FindAsync(id);
        if (match == null)
        {
            return NotFound();
        }

        _context.matches.Remove(match);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MatchExists(Guid id)
    {
        return _context.matches.Any(e => e.Id == id);
    }
}
