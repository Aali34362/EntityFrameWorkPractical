using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.Response;
using AutoMapper;
using EntityFrameworkCore.Api.DTO;

namespace EntityFrameworkCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaguesController(FootballLeagueApiDBContext context, IMapper mapper) : ControllerBase
{
    private readonly FootballLeagueApiDBContext _context = context;
    private readonly IMapper _mapper = mapper;

    // GET: api/Leagues
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeagueList>>> Getleagues()
    {
        List<League> League = await _context.leagues.ToListAsync();
        List<LeagueList> LeagueList = _mapper.Map<List<League>, List<LeagueList>>(League);
        return LeagueList;
    }

    // GET: api/Leagues/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeagueDetails>> GetLeague(Guid id)
    {
        League league = await _context.leagues.FindAsync(id);
        LeagueDetails LeagueList = _mapper.Map<League, LeagueDetails>(league);
        if (league == null)
        {
            return NotFound();
        }
        return LeagueList;
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
    public async Task<ActionResult<League>> PostLeague(LeagueDto league)
    {
        League league1 = _mapper.Map<LeagueDto, League>(league);
        _context.leagues.Add(league1);
        await _context.SaveChangesAsync();
        LeagueDetails LeagueDetails = _mapper.Map<League, LeagueDetails>(league1);
        return CreatedAtAction("GetLeague", new { id = LeagueDetails.Id }, LeagueDetails);
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
