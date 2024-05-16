using EntityFrameWorkCore.Data.ScaffoldContext;
using EntityFrameWorkCore.Domain.DataModel;
using EntityFrameWorkCore.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EntityFrameWorkCore.Data.Context;

public class FootballLeagueApiDBContext : DbContext
{
    public FootballLeagueApiDBContext(DbContextOptions<FootballLeagueApiDBContext> options) : base(options)
    {

    }

    public DbSet<Team> teams { get; set; }
    public DbSet<Coach> coaches { get; set; }
    public DbSet<League> leagues { get; set; }
    public DbSet<Match> matches { get; set; }
    public DbSet<TeamsAndLeaguesView> teamsandleaguesview { get; set; }
    public string DbPath { get; private set; }
    // Private Set : This is similar to set, but it restricts access to the setter to within the class where the property is defined. It's useful when you want to allow external code to read the property but not modify it directly.
    //
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<TeamsAndLeaguesView>()
            .HasNoKey().ToView("vw_TeamsAndLeagues");

        //For using Functions in SqlServer.
        //modelBuilder.HasDbFunction(typeof(FootballLeagueDBContext)
        //    .GetMethod(nameof(GetEarliestTeamMatch), new[] { typeof(Guid) }))
        //    .HasName("GetEarliestTeamMatch");
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

public class FootballLeagueApiDbContextFactory : IDesignTimeDbContextFactory<FootballLeagueApiDBContext>
{
    public FootballLeagueApiDBContext CreateDbContext(string[] args)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var sqliteDatabaseName = configuration.GetConnectionString("SqliteDatabaseConnectionString");

        var dbPath = Path.Combine(path, sqliteDatabaseName);

        var optionsBuilder = new DbContextOptionsBuilder<FootballLeagueApiDBContext>();
        optionsBuilder.UseSqlite($"Data Source = {dbPath}");

        return new FootballLeagueApiDBContext(optionsBuilder.Options);
    }
}