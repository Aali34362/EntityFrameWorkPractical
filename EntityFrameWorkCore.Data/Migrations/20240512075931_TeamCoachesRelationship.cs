using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamCoachesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_CoachId",
                table: "teams");

            migrationBuilder.AddColumn<string>(
                name: "TeamType",
                table: "teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamScore",
                table: "matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScpre",
                table: "matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teams_CoachId",
                table: "teams",
                column: "CoachId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_TeamName",
                table: "teams",
                column: "TeamName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matches_AwayTeamId",
                table: "matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_matches_HomeTeamId",
                table: "matches",
                column: "HomeTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_matches_teams_AwayTeamId",
                table: "matches",
                column: "AwayTeamId",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_matches_teams_HomeTeamId",
                table: "matches",
                column: "HomeTeamId",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams",
                column: "CoachId",
                principalTable: "coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_matches_teams_AwayTeamId",
                table: "matches");

            migrationBuilder.DropForeignKey(
                name: "FK_matches_teams_HomeTeamId",
                table: "matches");

            migrationBuilder.DropForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_CoachId",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_TeamName",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_matches_AwayTeamId",
                table: "matches");

            migrationBuilder.DropIndex(
                name: "IX_matches_HomeTeamId",
                table: "matches");

            migrationBuilder.DropColumn(
                name: "TeamType",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "AwayTeamScore",
                table: "matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamScpre",
                table: "matches");

            migrationBuilder.CreateIndex(
                name: "IX_teams_CoachId",
                table: "teams",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams",
                column: "CoachId",
                principalTable: "coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
