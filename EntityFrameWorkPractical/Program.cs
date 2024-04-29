using Bogus;
using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;


using var sqlitecontext = new FootballLeagueDBContext();

////Selecting a single record - first one in the list
//var teamOne = await sqlitecontext.coaches.FirstAsync();
//var teamOnes = await sqlitecontext.coaches.FirstOrDefaultAsync();

////Selecting a single record - first one in the list that meets the condition
//var teamtwo = await sqlitecontext.coaches.FirstAsync( x=> x.Name == "npkri");
//var teamtwos = await sqlitecontext.coaches.FirstOrDefaultAsync(x => x.Name == "fvrun");

////Selecting a single record - Only one record should be returned
//try
//{
//    var teamthree = await sqlitecontext.teams.SingleAsync();
//}
//catch (Exception) { throw; }
//var teamthrees = await sqlitecontext.teams.SingleAsync(team => team.TeamName.Equals("umrcpvtbzy"));

//var teamfour = await sqlitecontext.teams.SingleOrDefaultAsync();
//var teamfours = await sqlitecontext.teams.SingleOrDefaultAsync(team => team.TeamName.Equals("umrcpvtbzy"));

//Selecting based on ID
Guid Id = Guid.Parse("36CB09E6-45A9-4ED9-87A3-A13F8CB82E94");
var teamBasedOnId = await sqlitecontext.teams.FindAsync(Id);
Console.WriteLine(teamBasedOnId.TeamName);

await GetFilteredTeams();







async Task GetFilteredTeams()
{
    //Filter
    //Select all record that meet a condition 
    Console.WriteLine("Enter Desired Team");
    var desiredTeam = Console.ReadLine();
    var teamsFilter = await sqlitecontext.teams.Where(x => x.TeamName.Equals(desiredTeam)).ToListAsync();
    foreach (var team in teamsFilter)
    {
        Console.WriteLine(team.TeamName);
    }
}

























var yourClass = new YourClass();
await yourClass.GetAllTeams();

var firstTeam = await yourClass.GetFirstTeam("88750200-9FCC-4C91-909D-969F1F421634");
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

    public async Task<Team> GetFirstTeam(string Id)
    {
        try
        {
            Guid id = Guid.Parse(Id);
            var team = await _context
                .teams
                .FirstOrDefaultAsync( x=> (x.Id == id));
            return team;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            // Log or handle the exception as necessary
            return null;
        }
    }
}