using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Act_Ind = table.Column<bool>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Lst_Crtd_User = table.Column<string>(type: "TEXT", nullable: false),
                    Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Lst_Crtd_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Act_Ind = table.Column<bool>(type: "INTEGER", nullable: false),
                    Del_Ind = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coaches");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
