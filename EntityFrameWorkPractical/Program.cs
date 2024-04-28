using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;





var yourClass = new YourClass();
await yourClass.GetAllTeams();

var firstTeam = await yourClass.GetFirstTeam();
if (firstTeam != null)
{
    Console.WriteLine($"First team: {firstTeam.TeamName}");
}

// Dispose of the resources when done
yourClass.Dispose();








public class YourClass
{
    private readonly FootballLeagueDBContext _context;

    public YourClass()
    {
        _context = new FootballLeagueDBContext();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task GetAllTeams()
    {
        try
        {
            var teams = await _context.teams.ToListAsync();
            foreach (var team in teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Log or handle the exception as necessary
        }
    }

    public async Task<Team> GetFirstTeam()
    {
        try
        {
            var team = await _context.teams.FirstOrDefaultAsync();
            return team;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Log or handle the exception as necessary
            return null;
        }
    }

    // Additional methods...
}