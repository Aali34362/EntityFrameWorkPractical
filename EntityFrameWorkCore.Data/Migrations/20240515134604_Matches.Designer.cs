﻿// <auto-generated />
using System;
using EntityFrameWorkCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    [DbContext(typeof(FootballLeagueDBContext))]
    [Migration("20240515134604_Matches")]
    partial class Matches
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("coaches");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.League", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("leagues");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("AwayTeamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("HomeTeamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Match_Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("matches");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.RelationalModel.CoachAndTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoachId")
                        .IsUnique();

                    b.ToTable("CoachAndTeam");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.RelationalModel.TeamAndLeague", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId")
                        .IsUnique();

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("TeamAndLeague");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Act_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Lst_Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lst_Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamMembers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoachId")
                        .IsUnique();

                    b.HasIndex("LeagueId");

                    b.HasIndex("TeamName")
                        .IsUnique();

                    b.ToTable("teams");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Match", b =>
                {
                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.RelationalModel.CoachAndTeam", b =>
                {
                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Coach", "Coach")
                        .WithOne("CoachAndTeam")
                        .HasForeignKey("EntityFrameWorkCore.Domain.DataModel.RelationalModel.CoachAndTeam", "CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Team", "Team")
                        .WithOne("CoachAndTeam")
                        .HasForeignKey("EntityFrameWorkCore.Domain.DataModel.RelationalModel.CoachAndTeam", "CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.RelationalModel.TeamAndLeague", b =>
                {
                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.League", "League")
                        .WithOne("TeamAndLeague")
                        .HasForeignKey("EntityFrameWorkCore.Domain.DataModel.RelationalModel.TeamAndLeague", "LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Team", "Team")
                        .WithOne("TeamAndLeague")
                        .HasForeignKey("EntityFrameWorkCore.Domain.DataModel.RelationalModel.TeamAndLeague", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Team", b =>
                {
                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.Coach", "Coach")
                        .WithOne("Team")
                        .HasForeignKey("EntityFrameWorkCore.Domain.DataModel.Team", "CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("League");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Coach", b =>
                {
                    b.Navigation("CoachAndTeam");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.League", b =>
                {
                    b.Navigation("TeamAndLeague");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("CoachAndTeam");

                    b.Navigation("HomeMatches");

                    b.Navigation("TeamAndLeague");
                });
#pragma warning restore 612, 618
        }
    }
}
