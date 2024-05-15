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
    Name.Create("Erich", "Gamma"),
    Name.Create("Ralph", "Johnson"),
    Name.Create("Kernighan"),
    Name.Create("Ritchie")
);
var book = author is null ? null : Books.Create("The Missing Book", author);
var books = author.BindOptional(a => Books.Create("The Missing Books", a));

book?.Title.DoOptional(Console.WriteLine);

(book?.Authors ?? Array.Empty<NameType>())
    .Select(Printable)
    .ForEach(Console.WriteLine);

books?.Title.DoOptional(Console.WriteLine);

(books?.Authors ?? Array.Empty<NameType>())
    .Select(Printable)
    .ForEach(Console.WriteLine);

string Printable(NameType name) =>
    name.Match((first, last) => $"{last},{first[..2]}", mononym => $"{mononym}");


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
//await DeleteTables();

//////////////////Update
//await UpdateTeam();

//////////////////Insert
await InsertMatch();
await InsertMoreMatches();
//await InsertTeams();
//await InsertLeague();
//await InsertCoach();
//await InsertTeam();
//await InsertParentChild();
//await InsertParentwithChild();

////////////////////Get////////////////////
//await GetLazyLoading();
//await GetExplicityLoading();
//await GetEagerloading();
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
         .ExecuteUpdateAsync(set => set
         .SetProperty(prop => prop.Act_Ind, 0)
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
async Task DeleteTables()
{
    ////var coachToDelete = sqlitecontext.coaches.ToList();

    ////// Delete all records
    ////sqlitecontext.coaches.RemoveRange(coachToDelete);

    ////var leagueToDelete = sqlitecontext.leagues.ToList();

    ////// Delete all records
    ////sqlitecontext.leagues.RemoveRange(leagueToDelete);

    ////var teamsToDelete = sqlitecontext.teams.ToList();

    ////// Delete all records
    ////sqlitecontext.teams.RemoveRange(teamsToDelete);

    // Save changes to the database
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
async Task UpdateNoTracking()
{
    // We cannot use find with no tracking enabled, so we look for the FirstOrDefault()
    var coach1 = await sqlitecontext.coaches
        .AsNoTracking()
        .FirstOrDefaultAsync(q => q.Id == Guid.Parse(""));
    coach1.Name = "Testing No Tracking Behavior - Entity State Modified";

    // We can either call the Update() method or change the Entity State manually
    //context.Update(coach1);
    sqlitecontext.Entry(coach1).State = EntityState.Modified;
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

    foreach (var coach in coaches)
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

/*
 // Assuming you have access to your DbContext instance called dbContext

// Create teams
var team1 = new Team { TeamName = "Team 1", TeamMembers = 10, TeamType = "Type A" };
var team2 = new Team { TeamName = "Team 2", TeamMembers = 8, TeamType = "Type B" };

// Create leagues
var league1 = new League { Name = "League 1" };
var league2 = new League { Name = "League 2" };

// Assign teams to leagues
team1.LeagueTeams = new List<LeagueTeam>
{
    new LeagueTeam { Team = team1, League = league1 },
    new LeagueTeam { Team = team1, League = league2 }
};

team2.LeagueTeams = new List<LeagueTeam>
{
    new LeagueTeam { Team = team2, League = league1 }
};

// Add entities to DbContext and save changes
dbContext.Teams.AddRange(team1, team2);
dbContext.Leagues.AddRange(league1, league2);
dbContext.SaveChanges();
 */

async Task InsertTeam()
{
    List<Team> teams =
    [
        new() { TeamName = "Barcelona", TeamType = "Away Team", TeamMembers = 15,
            CoachId= Guid.Parse("CBC4B16C-F7F1-405D-B9D2-86A96EB87A8F"), LeagueId= Guid.Parse("027C4CFC-9985-4177-A586-50F12DC15F2E")},
        new() { TeamName = "Inter Milan", TeamType = "Home Team", TeamMembers = 11,
            CoachId= Guid.Parse("48FD09D6-3308-4014-9750-F1520FAA3F1C"), LeagueId= Guid.Parse("1578DAFB-A841-456D-B56D-54B91212AA8A")},
        new() { TeamName = "Brighton & Hove Albion", TeamType = "Away Team", TeamMembers = 15,
            CoachId= Guid.Parse("942DF259-2E32-45CA-A754-B5F9CDCD2CC4"), LeagueId= Guid.Parse("EA19350F-04A8-4CFD-812E-9294EF063896")},
        new() { TeamName = "Man United", TeamType = "Home Team", TeamMembers = 20,
            CoachId= Guid.Parse("F2DABB6F-128E-4D55-91AB-37DAE576AADC"), LeagueId= Guid.Parse("F085EC76-689F-4070-B79D-E86231FA7776")},
        new() { TeamName = "Argentina", TeamType = "Away Team",  TeamMembers = 35,
            CoachId= Guid.Parse("15B88162-E240-4358-8FAD-10D89AB4640C"), LeagueId= Guid.Parse("A7A1EF70-D26E-4FC9-96E4-E3A9F2C6064C")},
        new() { TeamName = "Liverpool", TeamType = "Home Team",  TeamMembers = 15,
            CoachId= Guid.Parse("A351FA1A-121C-402E-88EA-9CDE21C8D6B0"), LeagueId= Guid.Parse("F085EC76-689F-4070-B79D-E86231FA7776")},
        new() { TeamName = "Napoli", TeamType = "Away Team",  TeamMembers = 14,
            CoachId= Guid.Parse("ADB69D93-AEA3-491D-ABA6-726A3158A9B2"), LeagueId= Guid.Parse("2DF9E69C-0CFD-4E34-8B8F-DF97E20543CA")},
        new() { TeamName = "Real Madrid", TeamType = "Home Team",  TeamMembers = 17,
            CoachId= Guid.Parse("1CB9C61B-43A0-43C9-A12D-0A9BA6678512"), LeagueId= Guid.Parse("1BE1D564-86A0-40E9-A5EF-5A86CE664021")},
        new() { TeamName = "Man City", TeamType = "Home Team",  TeamMembers = 16,
            CoachId= Guid.Parse("9A4FAC42-4EAD-4932-BEC4-AED174716583"), LeagueId= Guid.Parse("2DF9E69C-0CFD-4E34-8B8F-DF97E20543CA")},
    ];
    await sqlitecontext.teams.AddRangeAsync(teams);
    await sqlitecontext.SaveChangesAsync();
}
async Task InsertCoach()
{
    List<Coach> coaches = [
        new() { Name = "XAVI, Barcelona" },
        new() { Name = "Simone INZAGHI, Inter Milan" },
        new() { Name = "Roberto DE ZERBI, Brighton & Hove Albion" },
        new() { Name = "Erik TEN HAG, Man United" },
        new() { Name = "Lionel SCALONI, Argentina" },
        new() { Name = "Jurgen KLOPP, Liverpool"},
        new() { Name = "Luciano SPALLETTI, Napoli" },
        new() { Name = "Carlo ANCELOTTI, Real Madrid" },
        new() { Name = "Pep GUARDIOLA, Man City" },
    ];
    await sqlitecontext.coaches.AddRangeAsync(coaches);
    await sqlitecontext.SaveChangesAsync();
}
async Task InsertLeague()
{
    List<League> leagues = new List<League>()
    {
        new League(){ Name = "EFL League" },
        new League(){ Name = "UEFA Champions League" },
        new League(){ Name = "Premier League" },
        new League(){ Name = "FIFA" },
        new League(){ Name = "English League Championship" },
        new League(){ Name = "German Bundesliga" },
        new League(){ Name = "French Ligue 1" },
        new League(){ Name = "Mexican Liga BBVA MX" },
        new League(){ Name = "Men's Olympic Tournament" },
        new League(){ Name = "Copa América" },
    };

    await sqlitecontext.leagues.AddRangeAsync(leagues);
    await sqlitecontext.SaveChangesAsync();
}
async Task InsertMatch()
{
    var match = new Match
    {
        AwayTeamId = Guid.Parse("34D27B09-D2C0-49B9-A1C0-2098EAC6DB13"),
        HomeTeamId = Guid.Parse("623F665E-9768-49DF-8635-C4CE26E657AA"),
        HomeTeamScore = 0,
        AwayTeamScore = 0,
        Match_Date = new DateTime(2023, 10, 1),
        TicketPrice = 20,
    };

    await sqlitecontext.AddAsync(match);
    await sqlitecontext.SaveChangesAsync();

    /* Incorrect reference data  - Will give error*/
    var match1 = new Match
    {
        AwayTeamId = Guid.Parse("35786C24-7D1C-4643-A648-1BE00C1A57D8"),
        HomeTeamId = Guid.Parse("6F2DB6B2-9EC0-4398-932D-81EAEBC485E4"),
        HomeTeamScore = 0,
        AwayTeamScore = 0,
        Match_Date = new DateTime(2023, 10, 1),
        TicketPrice = 20,
    };

    await sqlitecontext.AddAsync(match1);
    await sqlitecontext.SaveChangesAsync();
}
async Task InsertMoreMatches()
{
    var match1 = new Match
    {
        AwayTeamId = Guid.Parse("ABCD69E3-212D-46C8-973D-33778C476375"),
        HomeTeamId = Guid.Parse("73AD499F-3571-4882-9C64-00262C155DC7"),
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Match_Date = new DateTime(2023, 01, 1),
        TicketPrice = 20,
    };
    var match2 = new Match
    {
        AwayTeamId = Guid.Parse("D7453B2C-031E-4302-9A3D-7E0CC09E0427"),
        HomeTeamId = Guid.Parse("D2CBEC29-26F7-460D-B0D4-A5010FCCCC27"),
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Match_Date = new DateTime(2023, 01, 1),
        TicketPrice = 20,
    };
    var match3 = new Match
    {
        AwayTeamId = Guid.Parse("A44F81EC-1571-4226-AAC9-8891E88BE56C"),
        HomeTeamId = Guid.Parse("4113E2FF-381E-49FF-A8EC-9E21EAA1C41B"),
        HomeTeamScore = 1,
        AwayTeamScore = 0,
        Match_Date = new DateTime(2023, 01, 1),
        TicketPrice = 20,
    };
    var match4 = new Match
    {
        AwayTeamId = Guid.Parse("5BB8C33B-0727-43EC-BD2D-7B7220134FB8"),
        HomeTeamId = Guid.Parse("BAF65EA0-801F-42DF-9D78-B28C62F4B12F"),
        HomeTeamScore = 0,
        AwayTeamScore = 1,
        Match_Date = new DateTime(2023, 01, 1),
        TicketPrice = 20,
    };
    await sqlitecontext.AddRangeAsync(match1, match2, match3, match4);
    await sqlitecontext.SaveChangesAsync();
}

#region Related Data
//Insert Record with FK
async Task InsertRelationalData()
{
    var match = new Match
    {
        AwayTeamId = Guid.NewGuid(),
        HomeTeamId = Guid.NewGuid(),
        HomeTeamScore = 1,
        AwayTeamScore = 2,
        Match_Date = DateTime.Now,
        TicketPrice = 500
    };
    await sqlitecontext.AddAsync(match);
    await sqlitecontext.SaveChangesAsync();
}
//Insert Parent/Child
async Task InsertParentChild()
{
    var team = new Team
    {
        TeamName = "XYZ",
        TeamType = "Away Team",
        TeamMembers = 18,
        Coach = new Coach
        {
            Name = "XYZ"
        },
        League = new League
        {
            Name = "XYZ"
        }
    };
    await sqlitecontext.teams.AddAsync(team);
    await sqlitecontext.SaveChangesAsync();
}
//Insert Parent with Children
async Task InsertParentwithChild()
{
    var league = new League
    {
        Teams = new List<Team>
        {
            new() {
                TeamName = "ABC",
                TeamType = "Home Team",
                TeamMembers = 12,
                Coach = new Coach
                {
                    Name = "ABC"
                }
            },
            new() {
                TeamName = "LMNO",
                TeamType = "Away Team",
                TeamMembers = 14,
                Coach = new Coach
                {
                    Name = "LMNO"
                }
            }
        }
    };

    ////var teamsToAdd = new List<Team>();
    ////foreach (var team in league.Teams)
    ////{
    ////    // Check if the team already exists
    ////    var existingTeam = await sqlitecontext.teams
    ////        .Include(t => t.Coach)
    ////        .FirstOrDefaultAsync(t => t.TeamName == team.TeamName);

    ////    if (existingTeam != null)
    ////    {
    ////        // If the team exists, attach it to the new league
    ////        league.Teams.Remove(team);
    ////        league.Teams.Add(existingTeam);
    ////    }
    ////    else
    ////    {
    ////        // If the team doesn't exist, prepare it for addition
    ////        teamsToAdd.Add(team);
    ////    }
    ////}

    await sqlitecontext.leagues.AddRangeAsync(league);
    await sqlitecontext.SaveChangesAsync();
}
#endregion

/////////////////////GET///////////////////////////

//Lazy Loading
async Task GetLazyLoading()
{
    Console.WriteLine("GetLazyLoading");
    var league = await sqlitecontext.FindAsync<League>(Guid.Parse("2DF9E69C-0CFD-4E34-8B8F-DF97E20543CA"));
    Console.WriteLine(league.Name);
    if (league.Teams.Any())
        Console.WriteLine(string.Join(", ", league.Teams.Select(x => $"{x.TeamName}")));

    foreach(var leagues in await sqlitecontext.leagues.ToListAsync())
    {
        Console.WriteLine(leagues.Name);
        if (league.Teams.Any())
            Console.WriteLine(string.Join(", ", leagues.Teams.Select(x => $"{x.TeamName} - {x.Coach.Name}")));
    }

}
//Explicit Loading
async Task GetExplicityLoading()
{
    Console.WriteLine("GetExplicityLoading");
    var league = await sqlitecontext.FindAsync<League>(Guid.Parse("2DF9E69C-0CFD-4E34-8B8F-DF97E20543CA"));
    //Loading Teams
    sqlitecontext.Entry(league).Collection(q => q.Teams).Load();
    Console.WriteLine(league.Name);
    if (league.Teams.Any())
        Console.WriteLine(string.Join(", ", league.Teams.Select(x => $"{x.TeamName}")));

}
//Eager Loading
async Task GetEagerloading()
{
    Console.WriteLine("GetEagerloading");
    var leagues = await sqlitecontext.leagues
        //.Include("Teams") 
        .Include(q => q.Teams)//Loading Teams
        .ThenInclude(q => q.Coach)//Loading Coach
        .ToListAsync();
    foreach (var league in leagues)
    {
        Console.WriteLine(league.Name);
        if (league.Teams.Count > 0)
            Console.WriteLine(string.Join(", ", league.Teams.Select(x => $"{x.TeamName} - {x.Coach.Name}")));
    }
}
async Task GetIQueryable()
{
    //IQueryables vs List Types
    Console.WriteLine("Enter '10' for team with members 10 or 12 for teams that contain 'Q'");
    var option = Convert.ToInt32(Console.ReadLine());
    List<Team> teamsAsList = [];

    //after executing ToListAsync, the records are loaded into memory. Any operation is then done in memory
    teamsAsList = await sqlitecontext.teams.ToListAsync();
    if (option == 1)
    {
        teamsAsList = teamsAsList
            .Where(q => q.TeamMembers == 10)
            .ToList();
    }
    else if (option == 2)
    {
        teamsAsList = teamsAsList
            .Where(q => q.TeamName.Contains("q"))
            .ToList();
    }
    foreach (var t in teamsAsList) { Console.WriteLine(t.TeamName); }

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
    foreach (var names in teamNames) { Console.WriteLine(names); }

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
    foreach (var group in groupTeams)
    {
        Console.WriteLine(group.Key);
        foreach (var team in group)
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

    while (next)
    {
        var teams = await sqlitecontext
            .teams
            .Skip(page * recordCount)
            .Take(recordCount)
            .ToListAsync();

        foreach (var team in teams)
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
    foreach (var t in teams) { Console.WriteLine(t.TeamName); }


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
        .Where(x => EF.Functions.Like(x.TeamName, searchTeam2))
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
                .FirstOrDefaultAsync(x => (x.Id == id));
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