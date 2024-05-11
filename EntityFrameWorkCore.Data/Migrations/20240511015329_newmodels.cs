using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("05006a7f-711b-4f4c-bc72-ed86f13eb233"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("a14014e4-e253-4be3-82f9-8064b4d14aad"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("be4c9da2-29d3-43a7-8d3f-96d1e92ba560"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("d2787e2c-13e0-45e3-b9e0-521d37372d91"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("da33e9d6-a770-4553-bb57-8f52cd603aa3"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("28dba2a0-ed24-4a2f-a731-30a7d072a525"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("355e1747-2ef3-40aa-a1a4-c5e94c167949"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("75b0f6e6-855e-4832-be2a-f2c17e6fe0e3"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("83565a8e-2832-4170-b7e1-053eb13ee77b"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("f90f4e52-5a1b-4d41-84f1-d5dfc660f90f"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoachId",
                table: "teams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LeagueId",
                table: "teams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HomeTeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AwayTeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Match_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leagues");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "teams");

            migrationBuilder.InsertData(
                table: "coaches",
                columns: new[] { "Id", "Act_Ind", "Crtd_Date", "Crtd_User", "Del_Ind", "Lst_Crtd_Date", "Lst_Crtd_User", "Name" },
                values: new object[,]
                {
                    { new Guid("05006a7f-711b-4f4c-bc72-ed86f13eb233"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1530), "vwuzufm", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1530), "scyyqzs", "jswt " },
                    { new Guid("a14014e4-e253-4be3-82f9-8064b4d14aad"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1465), "yqwcwfc", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1465), "woxvmhk", "wtzqc" },
                    { new Guid("be4c9da2-29d3-43a7-8d3f-96d1e92ba560"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1508), "zeabdel", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1509), "yyqiuxt", "adalx" },
                    { new Guid("d2787e2c-13e0-45e3-b9e0-521d37372d91"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1486), "qehmacr", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1487), "ohrsbbb", "trknz" },
                    { new Guid("da33e9d6-a770-4553-bb57-8f52cd603aa3"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1432), "wcqnjya", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1433), "ydsvdjr", "xzrz " }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Act_Ind", "Crtd_Date", "Crtd_User", "Del_Ind", "Lst_Crtd_Date", "Lst_Crtd_User", "TeamMembers", "TeamName" },
                values: new object[,]
                {
                    { new Guid("28dba2a0-ed24-4a2f-a731-30a7d072a525"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1074), "vhylp o", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1074), "ftlziuv", 9, "gjkjybidvc" },
                    { new Guid("355e1747-2ef3-40aa-a1a4-c5e94c167949"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(869), "vgjpwoo", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(880), "qzmxtuk", 10, "pbfvwzqxqv" },
                    { new Guid("75b0f6e6-855e-4832-be2a-f2c17e6fe0e3"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1136), "vgttnmj", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1137), "ujvgyff", 6, "xagccx mbj" },
                    { new Guid("83565a8e-2832-4170-b7e1-053eb13ee77b"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1030), "xajinma", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1032), "fahizjg", 12, "fww pqxgff" },
                    { new Guid("f90f4e52-5a1b-4d41-84f1-d5dfc660f90f"), (short)1, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1113), "awiyzm ", (short)0, new DateTime(2024, 5, 1, 23, 11, 25, 796, DateTimeKind.Unspecified).AddTicks(1114), "kruerpd", 15, "yabmsktzhh" }
                });
        }
    }
}
