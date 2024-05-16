using Dumpify;
using EntityFrameWorkCore.Data.Configuration;
using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EntityFrameWorkCore.Data.Context;

public class FootballLeagueDBContext : DbContext
{
    public DbSet<Team> teams { get; set; }
    public DbSet<Coach> coaches { get; set; }
    public DbSet<League> leagues { get; set; }
    public DbSet<Match> matches { get; set; }
    public DbSet<TeamsAndLeaguesView> teamsandleaguesview { get; set; }
    public string DbPath { get; private set; }
    // Private Set : This is similar to set, but it restricts access to the setter to within the class where the property is defined. It's useful when you want to allow external code to read the property but not modify it directly.
    //
    public FootballLeagueDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Console.WriteLine(path);
        DbPath = Path.Combine(path, "FootballLeague_EFCore.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder
        //    .UseSqlServer("Server=UCHIHA_MADARA\\SQLEXPRESS;Database=FootballLeague;User=UCHIHA_MADARA\\aa882;Password=; " +
        //    "MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=true;Connection Timeout=6000;Trusted_Connection=True;");

        optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .UseLazyLoadingProxies()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
            .LogTo(Console.WriteLine, LogLevel.Information)//Logging the information
            .EnableSensitiveDataLogging()// not to use in production just for educational purpose to look into data traversing 
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<TeamsAndLeaguesView>()
            .HasNoKey().ToView("vw_TeamsAndLeagues");

        //For using Functions in SqlServer.
        //modelBuilder.HasDbFunction(typeof(FootballLeagueDBContext)
        //    .GetMethod(nameof(GetEarliestTeamMatch), new[] { typeof(Guid) }))
        //    .HasName("GetEarliestTeamMatch");

        ////modelBuilder.Entity<Team>()
        ////    .HasData(
        ////        new Team
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            TeamName = GenerateRandomString(10),
        ////            TeamMembers = 10,
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Team
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            TeamName = GenerateRandomString(10),
        ////            TeamMembers = 12,
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Team
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            TeamName = GenerateRandomString(10),
        ////            TeamMembers = 9,
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Team
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            TeamName = GenerateRandomString(10),
        ////            TeamMembers = 15,
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Team
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            TeamName = GenerateRandomString(10),
        ////            TeamMembers = 6,
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        }
        ////    );
        ////modelBuilder.Entity<Coach>()
        ////    .HasData(
        ////        new Coach
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            Name = GenerateRandomString(5),
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Coach
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            Name = GenerateRandomString(5),
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Coach
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            Name = GenerateRandomString(5),
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Coach
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            Name = GenerateRandomString(5),
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        },
        ////        new Coach
        ////        {
        ////            Id = Guid.NewGuid(),
        ////            Name = GenerateRandomString(5),
        ////            Act_Ind = 1,
        ////            Del_Ind = 0,
        ////            Crtd_User = GenerateRandomString(7),
        ////            Lst_Crtd_User = GenerateRandomString(7),
        ////        }
        ////    );
    }

    public DateTime GetEarliestTeamMatch(Guid Id) => throw new NotImplementedException();
    static string GenerateRandomString(int length)
    {
        Random random = new Random();
        string chars = "abcdefghijklmnopqrstuvwxyz ";
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }
        return new string(result);
    }
}