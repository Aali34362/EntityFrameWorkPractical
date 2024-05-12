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
    [Migration("20240511085723_seedsModel1")]
    partial class seedsModel1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

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

                    b.Property<DateTime>("Crtd_Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crtd_User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Del_Ind")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("HomeTeamId")
                        .HasColumnType("TEXT");

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

                    b.ToTable("matches");
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

                    b.Property<int>("TeamMembers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Team", b =>
                {
                    b.HasOne("EntityFrameWorkCore.Domain.DataModel.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.League", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
