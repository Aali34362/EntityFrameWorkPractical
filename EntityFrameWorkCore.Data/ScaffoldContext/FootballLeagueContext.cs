using System;
using System.Collections.Generic;
using EntityFrameWorkCore.Data.ScaffoldModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore.Data.ScaffoldContext;

public partial class FootballLeagueContext : DbContext
{
    public FootballLeagueContext()
    {
    }

    public FootballLeagueContext(DbContextOptions<FootballLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=UCHIHA_MADARA\\SQLEXPRESS;Database=FootballLeague;User=UCHIHA_MADARA\\aa882;Password=; MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=true;Connection Timeout=6000;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("coaches");

            entity.Property(e => e.ActInd).HasColumnName("Act_Ind");
            entity.Property(e => e.CrtdDate)
                .HasColumnType("datetime")
                .HasColumnName("Crtd_Date");
            entity.Property(e => e.CrtdUser)
                .HasMaxLength(50)
                .HasColumnName("Crtd_User");
            entity.Property(e => e.DelInd).HasColumnName("Del_Ind");
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LstCrtdDate)
                .HasColumnType("datetime")
                .HasColumnName("Lst_Crtd_Date");
            entity.Property(e => e.LstCrtdUser)
                .HasMaxLength(50)
                .HasColumnName("Lst_Crtd_User");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("teams");

            entity.Property(e => e.ActInd).HasColumnName("Act_Ind");
            entity.Property(e => e.CrtdDate)
                .HasColumnType("datetime")
                .HasColumnName("Crtd_Date");
            entity.Property(e => e.CrtdUser)
                .HasMaxLength(50)
                .HasColumnName("Crtd_User");
            entity.Property(e => e.DelInd).HasColumnName("Del_Ind");
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LstCrtdDate)
                .HasColumnType("datetime")
                .HasColumnName("Lst_Crtd_Date");
            entity.Property(e => e.LstCrtdUser)
                .HasMaxLength(50)
                .HasColumnName("Lst_Crtd_User");
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
