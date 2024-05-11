using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_teams_LeagueId",
                table: "teams",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_leagues_LeagueId",
                table: "teams",
                column: "LeagueId",
                principalTable: "leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_leagues_LeagueId",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "IX_teams_LeagueId",
                table: "teams");
        }
    }
}
