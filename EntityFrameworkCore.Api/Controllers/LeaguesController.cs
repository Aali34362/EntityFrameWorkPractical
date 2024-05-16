using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;

namespace EntityFrameworkCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaguesController : ControllerBase
{
    private readonly FootballLeagueApiDBContext _context;

    public LeaguesController(FootballLeagueApiDBContext context)
    {
        _context = context;
    }

    // GET: api/Leagues
    [HttpGet]
    public async Task<ActionResult<IEnumerable<League>>> Getleagues()
    {
        return await _context.leagues.ToListAsync();
    }

    // GET: api/Leagues/5
    [HttpGet("{id}")]
    public async Task<ActionResult<League>> GetLeague(Guid id)
    {
        var league = await _context.leagues.FindAsync(id);

        if (league == null)
        {
            return NotFound();
        }

        return league;
    }

    // PUT: api/Leagues/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeague(Guid id, League league)
    {
        if (id != league.Id)
        {
            return BadRequest();
        }

        _context.Entry(league).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeagueExists(id))
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

    // POST: api/Leagues
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<League>> PostLeague(League league)
    {
        _context.leagues.Add(league);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLeague", new { id = league.Id }, league);
    }

    // DELETE: api/Leagues/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeague(Guid id)
    {
        var league = await _context.leagues.FindAsync(id);
        if (league == null)
        {
            return NotFound();
        }

        _context.leagues.Remove(league);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LeagueExists(Guid id)
    {
        return _context.leagues.Any(e => e.Id == id);
    }
}
