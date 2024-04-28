using EntityFrameWorkCore.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace EntityFrameWorkCore.Data.Context;

public class FootballLeagueDBContext : DbContext
{

    //public FootballLeagueDBContext(DbContextOptions options) : base(options)
    //{

    //}

    public DbSet<Team> teams { get; set; }
    public DbSet<Coach> coaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder
        //    .UseSqlServer("Server=UCHIHA_MADARA\\SQLEXPRESS;Database=FootballLeague;User=UCHIHA_MADARA\\aa882;Password=; " +
        //    "MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=true;Connection Timeout=6000;Trusted_Connection=True;");

        optionsBuilder.UseSqlite($"Data Source=FootballLeague_EFCore.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasData(
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
                    Act_Ind = 1,
                    Del_Ind = 0,
                    Crtd_User = GenerateRandomString(7),
                    Lst_Crtd_User = GenerateRandomString(7),
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    TeamName = GenerateRandomString(10),
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