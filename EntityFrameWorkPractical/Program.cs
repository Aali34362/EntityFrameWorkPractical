using EntityFrameWorkCore.Data.Context;
using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkPractical.ZoranHorvatProgrammingCode;

var authors = new[]
{
    Name.Create("Erich","Gamma"),
    Name.Create("Ralph","Johnson"),
    Name.Create("Kernighan"),
    Name.Create("Ritchie")
};

NameType[]? author = Name.CreateMany(
    Name.Create("Erich","Gamma"),
    Name.Create("Ralph","Johnson"),
    Name.Create("Kernighan"),
    Name.Create("Ritchie")
);
var book = author is null ? null : Books.Create("The Missing Book", author);
var books = author.BindOptional(a=> Books.Create("The Missing Books", a));

book?.Title.DoOptional(Console.WriteLine);

(book?.Authors ?? Array.Empty<NameType>())
    .Select(Printable)
    .ForEach(Console.WriteLine);

books?.Title.DoOptional(Console.WriteLine);

(books?.Authors ?? Array.Empty<NameType>())
    .Select(Printable)
    .ForEach(Console.WriteLine);

string Printable(NameType name) =>
    name.Match((first, last) => $"{last},{first[..2]}",mononym => $"{mononym}");


//////////////////////////////////////////////////////////////////////////////////////////////////////////
using var sqlitecontext = new FootballLeagueDBContext();
//We can run Update Migration Command from this piece of code
////await sqlitecontext.Database.MigrateAsync();

//////////////////Execute Update
//await ExecuteUpdateTeam();

//////////////////Execute Delete
//await ExecuteDeleteTeam();

//////////////////Delete
//await DeleteTeam();

//////////////////Update
//await UpdateTeam();

//////////////////Insert
//await InsertTeams();

////////////////////Get////////////////////
//await GetTeams();
//await GetFilteredTeams();
//await GetAllTeamsQuerySyntax();
//await GetAggregateMethods();
//await GetProjections();
//await GetNoTrackingandTracking();
//await GetIQueryable();


///////////////////////Execute Update////////////////////////
async Task ExecuteUpdateTeam()
{
    ////var coach = await sqlitecontext.coaches.Where(q=> q.Name == "XYZ").ToListAsync();
    ////sqlitecontext.RemoveRange(coach);
    ////await sqlitecontext.SaveChangesAsync();

    await sqlitecontext.coaches
         .Where(q => q.Name == "XYZ")
         .ExecuteUpdateAsync(set=> set
         .SetProperty(prop=> prop.Act_Ind,0) 
         .SetProperty(prop => prop.Del_Ind, 1));
}

///////////////////////Execute Delete////////////////////////
async Task ExecuteDeleteTeam()
{
    ////var coach = await sqlitecontext.coaches.Where(q=> q.Name == "XYZ").ToListAsync();
    ////sqlitecontext.RemoveRange(coach);
    ////await sqlitecontext.SaveChangesAsync();

   await sqlitecontext.coaches
        .Where(q => q.Name == "XYZ")
        .ExecuteDeleteAsync();
}

///////////////////////Delete////////////////////////
async Task DeleteTeam()
{
    Guid coachId = Guid.Parse("8B0E7FE2-7F68-4544-BCBB-C5F0F99294CE");
    var coach = await sqlitecontext.coaches.FindAsync(coachId);
    sqlitecontext.Remove(coach);
    await sqlitecontext.SaveChangesAsync();

    Guid coachesId = Guid.Parse("87D2AB0A-115A-4DD2-9B6F-369CEBDA4581");
    var coaches = await sqlitecontext.coaches
        .AsNoTracking()
        .FirstOrDefaultAsync(a => a.Id == coachesId);
    sqlitecontext.Entry(coaches).State = EntityState.Deleted;
    await sqlitecontext.SaveChangesAsync();

}

///////////////////////Update////////////////////////
async Task UpdateTeam()
{
    Guid coachId = Guid.Parse("8B0E7FE2-7F68-4544-BCBB-C5F0F99294CE");
    var coach = await sqlitecontext.coaches.FindAsync(coachId);
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(coach));
    coach.Name = "ABCDEF";
    coach.Lst_Crtd_Date = DateTime.Now;
    await sqlitecontext.SaveChangesAsync();

    Guid coachesId = Guid.Parse("87D2AB0A-115A-4DD2-9B6F-369CEBDA4581");
    var coaches = await sqlitecontext.coaches
        .AsNoTracking()
        .FirstOrDefaultAsync(a => a.Id == coachesId);
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(coaches));
    coaches.Name = "XYZ";
    coaches.Lst_Crtd_Date = DateTime.Now;
    sqlitecontext.Update(coaches);
    await sqlitecontext.SaveChangesAsync();

}

///////////////////////INSERT////////////////////////
async Task InsertTeams()
{
    //Inserting Data
    //InsertTeams into coaches (cols) values (values)


    //Simple Insert
    var newCoach = new Coach
    {
        Name = "XYZ"
    };
    //await sqlitecontext.coaches.AddAsync(newCoach);
    //await sqlitecontext.SaveChangesAsync();
    
    //Loop Insert
    var newCoach1 = new Coach
    {
        Name = "XYZAD"
    };
    var newCoach2 = new Coach
    {
        Name = "XYZBC",
        Act_Ind = 0,
        Del_Ind = 1
    };
    
    List<Coach> coaches = [];    
    coaches.Add(newCoach1);
    coaches.Add(newCoach2);
    
    foreach(var coach in coaches)
    {
        await sqlitecontext.coaches.AddAsync(coach);
    }
    Console.WriteLine(sqlitecontext.ChangeTracker.DebugView.LongView);
    await sqlitecontext.SaveChangesAsync();
    Console.WriteLine(sqlitecontext.ChangeTracker.DebugView.LongView);

    //Batch Insert
    var newCoach3 = new Coach
    {
        Name = "XYZAD"
    };
    var newCoach4 = new Coach
    {
        Name = "XYZBC",
        Act_Ind = 0,
        Del_Ind = 1
    };
    List<Coach> coaches1 = [];
    coaches1.Add(newCoach3);
    coaches1.Add(newCoach4);
    await sqlitecontext.coaches.AddRangeAsync(coaches1);
    await sqlitecontext.SaveChangesAsync();

    //Bulk Insert
}

/////////////////////GET///////////////////////////
async Task GetIQueryable()
{
    //IQueryables vs List Types
    Console.WriteLine("Enter '10' for team with members 10 or 12 for teams that contain 'Q'");
    var option = Convert.ToInt32(Console.ReadLine());
    List<Team> teamsAsList = [];

    //after executing ToListAsync, the records are loaded into memory. Any operation is then done in memory
    teamsAsList = await sqlitecontext.teams.ToListAsync();
    if(option == 1)
    {
        teamsAsList = teamsAsList
            .Where(q => q.TeamMembers == 10 )
            .ToList();
    }
    else if(option == 2)
    {
        teamsAsList = teamsAsList
            .Where(q => q.TeamName.Contains("q"))
            .ToList();
    }
    foreach(var t in teamsAsList) { Console.WriteLine(t.TeamName); }

    //Records stay as IQueryable until the ToListAsync is executed, then the final query is performed.
    var teamsAsQuerable = sqlitecontext.teams.AsQueryable();
    if (option == 1)
    {
        teamsAsQuerable = teamsAsQuerable
            .Where(q => q.TeamMembers == 10);
    }
    else if (option == 2)
    {
        teamsAsQuerable = teamsAsQuerable
            .Where(q => q.TeamName.Contains("q"));
    }
    foreach (var t in teamsAsList) { Console.WriteLine(t.TeamName); }
    
    // in list we called all the data and then filtered out the data
    // in asqueryable() we seek the condition where ever its declared and then bring exact data related to condition of filter.

}
async Task GetNoTrackingandTracking()
{
    //No Tracking - EF core tracks objects that are returned by queries
    //This is less useful in disconnected application like Apis and web apps

    var teams = await sqlitecontext
        .teams
        .AsNoTracking()
        .ToListAsync();
}
async Task GetProjections()
{
    //Select and projections - more precise queries
    var teamNames = await sqlitecontext
        .teams
        .Select(a => a.TeamName)
        .ToListAsync();
    foreach(var names in teamNames) { Console.WriteLine(names); }

    //Projection
    var teamProjection = await sqlitecontext
        .teams
        .Select(a => new { a.TeamName, a.Id })
        .ToListAsync();
    foreach (var teams in teamProjection) { Console.WriteLine(teams.Id + " " + teams.TeamName); }

    var teamProjections = await sqlitecontext
            .teams
            .Select(a => new TeamInfo
            { 
                TeamName = a.TeamName, 
                TeamId = a.Id
             })
            .ToListAsync();
    foreach (var teams in teamProjections) 
    { 
        Console.WriteLine($"{teams.TeamId} {teams.TeamName}");
    }

}
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

    var orderedAscTeams = await sqlitecontext
        .teams
        .OrderBy(a => a.TeamName)
        .ToListAsync();

    var orderedDescTeams = await sqlitecontext
        .teams
        .OrderByDescending(a => a.TeamName)
        .ToListAsync();

    var MaxByDesc = sqlitecontext
        .teams
        .OrderByDescending(a => a.Id)
        .FirstOrDefaultAsync();

    var MaxBy = sqlitecontext.teams.MaxBy(a => a.Id);

    var MinByDesc = sqlitecontext
        .teams
        .OrderByDescending(a => a.Id)
        .LastOrDefaultAsync();

    var MinBy = sqlitecontext.teams.MinBy(a => a.Id);

    //Skip and take - Great for Paging
    var recordCount = 3;
    var page = 0;
    var next = true;

    while(next)
    {
        var teams = await sqlitecontext
            .teams
            .Skip(page * recordCount)
            .Take(recordCount)
            .ToListAsync();

        foreach(var team in teams)
        {
            Console.WriteLine(team.TeamName);
        }
        Console.WriteLine("Emter 'true' for the next set of records, 'False' to exit");
        next = Convert.ToBoolean(Console.ReadLine());
        if (!next) break;
        page++;
    }
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

//////////////////////////////////////////////////////////////////////////////////////////
var yourClass = new YourClass();
//await yourClass.GetAllTeams();

//var firstTeam = await yourClass.GetFirstTeam("88750200-9FCC-4C91-909D-969F1F421634");
//if (firstTeam != null)
//{
//    Console.WriteLine($"First team: {firstTeam.TeamName}");
//}

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
//////////////////////////////////////////////////////////////////////////////////////////
public class TeamInfo
{
    public Guid TeamId { get; set; }
    public string? TeamName { get; set; }
}