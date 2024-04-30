using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;

using var sqlitecontext = new FootballLeagueDBContext();


await GetTeams();
await GetFilteredTeams();
await GetAllTeamsQuerySyntax();
await GetAggregateMethods();





async Task GetAggregateMethods()
{
    var numerOfTeams = await sqlitecontext.teams.CountAsync();
    Console.WriteLine($"Count of team {numerOfTeams}");

    var querynumerOfTeams = await sqlitecontext
        .teams
        .CountAsync(x => x.TeamName.Equals("gbghlftmzs"));
    Console.WriteLine($"Count of query team {querynumerOfTeams}");

    var maxTeam = await sqlitecontext.teams.MaxAsync(x => x.Act_Ind);

    var minTeam = await sqlitecontext.teams.MinAsync(x => x.Act_Ind);

    var avgTeam = await sqlitecontext.teams.AverageAsync(x => x.Act_Ind);

    var sumTeam = await sqlitecontext.teams.SumAsync(x => x.Act_Ind);

    var groupTeams = sqlitecontext
        .teams
        //.Where()// Translates to a Where Clause
        .GroupBy(x => x.Crtd_Date.Date)
        //.Where() // Translates to a Having clause
        ;
    foreach(var group in groupTeams)
    {
        Console.WriteLine(group.Key);
        foreach(var team in group)
        {
            Console.WriteLine(team.TeamName);
        }
    }

    var groupMultipleTeams = sqlitecontext.teams.GroupBy(x => new { x.Crtd_Date.Date, x.TeamName, x.Act_Ind, x.Del_Ind });


}

async Task GetTeams()
{
    //Selecting a single record - first one in the list
    var teamOne = await sqlitecontext.coaches.FirstAsync();
    var teamOnes = await sqlitecontext.coaches.FirstOrDefaultAsync();

    //Selecting a single record - first one in the list that meets the condition
    var teamtwo = await sqlitecontext.coaches.FirstAsync(x => x.Name == "npkri");
    var teamtwos = await sqlitecontext.coaches.FirstOrDefaultAsync(x => x.Name == "fvrun");

    //Selecting a single record - Only one record should be returned
    try
    {
        var teamthree = await sqlitecontext.teams.SingleAsync();
    }
    catch (Exception) { throw; }
    var teamthrees = await sqlitecontext.teams.SingleAsync(team => team.TeamName.Equals("umrcpvtbzy"));

    var teamfour = await sqlitecontext.teams.SingleOrDefaultAsync();
    var teamfours = await sqlitecontext.teams.SingleOrDefaultAsync(team => team.TeamName.Equals("umrcpvtbzy"));

    //Selecting based on ID
    Guid Id = Guid.Parse("36CB09E6-45A9-4ED9-87A3-A13F8CB82E94");
    var teamBasedOnId = await sqlitecontext.teams.FindAsync(Id);
    Console.WriteLine(teamBasedOnId.TeamName);
}
async Task GetAllTeamsQuerySyntax()
{
    var teams = from team in sqlitecontext.teams select team;
    foreach(var t in teams){ Console.WriteLine(t.TeamName); }


    var methodlistteams = await (from team in sqlitecontext.teams select team).ToListAsync();
    foreach (var t in methodlistteams) { Console.WriteLine(t.TeamName); }

    Console.WriteLine("Enter Desired Team");
    var desiredTeam = Console.ReadLine();
    var methodlistteams1 = await (from team in sqlitecontext.teams
                                 where EF.Functions.Like(team.TeamName, $"%{desiredTeam}%")
                                 select team
                                 ).ToListAsync();
    foreach (var t in methodlistteams1) { Console.WriteLine(t.TeamName); }
}
async Task GetFilteredTeams()
{
    //Filter
    //Select all record that meet a condition 
    Console.WriteLine("Enter Desired Team");
    var desiredTeam = Console.ReadLine();
    var teamsFilter = await sqlitecontext
        .teams
        .Where(x => x.TeamName.Equals(desiredTeam))
        .ToListAsync();
    foreach (var team in teamsFilter)
    {
        Console.WriteLine(team.TeamName);
    }
    Console.WriteLine("Enter Search Team");
    var searchTeam = Console.ReadLine();
    var partialMatches = await sqlitecontext
        .teams
        .Where(x => x.TeamName.Equals(searchTeam))
        .ToListAsync();
    foreach (var team in partialMatches)
    {
        Console.WriteLine(team.TeamName);
    }

    Console.WriteLine("Enter Search Team 2");
    var searchTeam2 = Console.ReadLine();
    var partialMatches2 = await sqlitecontext
        .teams
        .Where( x=> EF.Functions.Like(x.TeamName, searchTeam2) )
        .ToListAsync();
    foreach (var team in partialMatches2)
    {
        Console.WriteLine(team.TeamName);
    }

    Console.WriteLine("Enter Search Team 3");
    var searchTeam3 = Console.ReadLine();
    var partialMatches3 = await sqlitecontext
        .teams
        .Where(x => EF.Functions.Like(x.TeamName, $"%{searchTeam3}%"))
        .ToListAsync();
    foreach (var team in partialMatches2)
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