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
    [Migration("20240428044203_SeededTeams")]
    partial class SeededTeams
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

            modelBuilder.Entity("EntityFrameWorkCore.Domain.DataModel.Team", b =>
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

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("15aea52f-3832-4da5-96d0-547bc371b11a"),
                            Act_Ind = (short)1,
                            Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1313),
                            Crtd_User = "",
                            Del_Ind = (short)0,
                            Lst_Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1321),
                            Lst_Crtd_User = "",
                            TeamName = "pvsuzwwugl"
                        },
                        new
                        {
                            Id = new Guid("e5b26df6-02ca-47f6-8288-35b570eb60ec"),
                            Act_Ind = (short)1,
                            Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1436),
                            Crtd_User = "",
                            Del_Ind = (short)0,
                            Lst_Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1437),
                            Lst_Crtd_User = "",
                            TeamName = "flkzasrzfm"
                        },
                        new
                        {
                            Id = new Guid("072f0a98-b9d8-4535-8d83-f977bb699a21"),
                            Act_Ind = (short)1,
                            Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1450),
                            Crtd_User = "",
                            Del_Ind = (short)0,
                            Lst_Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1450),
                            Lst_Crtd_User = "",
                            TeamName = " syhdivxdt"
                        },
                        new
                        {
                            Id = new Guid("83b4654c-4ce5-4f87-b384-28f38bb48a4c"),
                            Act_Ind = (short)1,
                            Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1483),
                            Crtd_User = "",
                            Del_Ind = (short)0,
                            Lst_Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1484),
                            Lst_Crtd_User = "",
                            TeamName = "vdirgaoday"
                        },
                        new
                        {
                            Id = new Guid("fe87683e-3913-4910-9f93-c4ab2ce97c62"),
                            Act_Ind = (short)1,
                            Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1495),
                            Crtd_User = "",
                            Del_Ind = (short)0,
                            Lst_Crtd_Date = new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1496),
                            Lst_Crtd_User = "",
                            TeamName = "xxwaxzzc w"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
