using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesinRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "coaches");

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
                name: "IX_TeamAndLeague_LeagueId",
                table: "TeamAndLeague",
                column: "LeagueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamAndLeague_TeamId",
                table: "TeamAndLeague",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams",
                column: "CoachId",
                principalTable: "coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams");

            migrationBuilder.DropTable(
                name: "CoachAndTeam");

            migrationBuilder.DropTable(
                name: "TeamAndLeague");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "coaches",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams",
                column: "CoachId",
                principalTable: "coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
