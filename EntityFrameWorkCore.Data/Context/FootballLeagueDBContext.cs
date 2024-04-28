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
        base.OnModelCreating(modelBuilder);
    }
}