using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class teamleagueview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vw_TeamsAndLeagues
                AS
                SELECT t.Name, l.Name AS LeagueName
                From Teams As t
                LEFT JOIN Leagues AS l on t.LeagueId = l.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP VIEW vw_TeamsAndLeagues
            ");
        }
    }
}
