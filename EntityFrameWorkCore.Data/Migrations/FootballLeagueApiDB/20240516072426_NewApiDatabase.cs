using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations.FootballLeagueApiDB
{
    /// <inheritdoc />
    public partial class NewApiDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.Id);
                });

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
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false),
                    TeamMembers = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamType = table.Column<string>(type: "TEXT", nullable: false),
                    CoachId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeagueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teams_leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachAndTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CoachId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachAndTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoachAndTeam_coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachAndTeam_teams_CoachId",
                        column: x => x.CoachId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HomeTeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "INTEGER", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_matches_teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matches_teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamAndLeague",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeagueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<short>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamAndLeague", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamAndLeague_leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamAndLeague_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachAndTeam_CoachId",
                table: "CoachAndTeam",
                column: "CoachId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matches_AwayTeamId",
                table: "matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_matches_HomeTeamId",
                table: "matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAndLeague_LeagueId",
                table: "TeamAndLeague",
                column: "LeagueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamAndLeague_TeamId",
                table: "TeamAndLeague",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_CoachId",
                table: "teams",
                column: "CoachId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_LeagueId",
                table: "teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_TeamName",
                table: "teams",
                column: "TeamName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachAndTeam");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "TeamAndLeague");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "leagues");
        }
    }
}
