using Dumpify;
using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameWorkCore.Data.Context;

public class FootballLeagueDBContext : DbContext
{
    public DbSet<Team> teams { get; set; }
    public DbSet<Coach> coaches { get; set; }
    public string DbPath { get; private set; }
    // Private Set : This is similar to set, but it restricts access to the setter to within the class where the property is defined. It's useful when you want to allow external code to read the property but not modify it directly.
    //
    public FootballLeagueDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "FootballLeague_EFCore.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder
        //    .UseSqlServer("Server=UCHIHA_MADARA\\SQLEXPRESS;Database=FootballLeague;User=UCHIHA_MADARA\\aa882;Password=; " +
        //    "MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=true;Connection Timeout=6000;Trusted_Connection=True;");
        
        optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(Console.WriteLine, LogLevel.Information)//Logging the information
            .EnableSensitiveDataLogging()// not to use in production just for educational purpose to look into data traversing 
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasData(
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    TeamMembers = 10,
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    TeamMembers = 12,
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    TeamMembers = 9,
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    TeamMembers = 15,
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    TeamMembers = 6,
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                }
            );
        modelBuilder.Entity<Coach>()
            .HasData(
                new Coach
                {
                    Id = Guid.NewGuid(),
                    Name = GenerateRandomString(5),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Coach
                {
                    Id = Guid.NewGuid(),
                    Name = GenerateRandomString(5),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Coach
                {
                    Id = Guid.NewGuid(),
                    Name = GenerateRandomString(5),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Coach
                {
                    Id = Guid.NewGuid(),
                    Name = GenerateRandomString(5),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                }, new Coach
                {
                    Id = Guid.NewGuid(),
                    Name = GenerateRandomString(5),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                }
            );
    }

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