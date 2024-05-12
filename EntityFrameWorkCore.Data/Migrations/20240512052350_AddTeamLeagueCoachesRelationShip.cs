using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamLeagueCoachesRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_coaches_CoachId",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_CoachId",
                table: "teams");
        }
    }
}
