using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Act_Ind", "Crtd_Date", "Crtd_User", "Del_Ind", "Lst_Crtd_Date", "Lst_Crtd_User", "TeamName" },
                values: new object[,]
                {
                    { new Guid("072f0a98-b9d8-4535-8d83-f977bb699a21"), (short)1, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1450), "", (short)0, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1450), "", " syhdivxdt" },
                    { new Guid("15aea52f-3832-4da5-96d0-547bc371b11a"), (short)1, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1313), "", (short)0, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1321), "", "pvsuzwwugl" },
                    { new Guid("83b4654c-4ce5-4f87-b384-28f38bb48a4c"), (short)1, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1483), "", (short)0, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1484), "", "vdirgaoday" },
                    { new Guid("e5b26df6-02ca-47f6-8288-35b570eb60ec"), (short)1, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1436), "", (short)0, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1437), "", "flkzasrzfm" },
                    { new Guid("fe87683e-3913-4910-9f93-c4ab2ce97c62"), (short)1, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1495), "", (short)0, new DateTime(2024, 4, 28, 4, 42, 0, 993, DateTimeKind.Unspecified).AddTicks(1496), "", "xxwaxzzc w" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("072f0a98-b9d8-4535-8d83-f977bb699a21"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("15aea52f-3832-4da5-96d0-547bc371b11a"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("83b4654c-4ce5-4f87-b384-28f38bb48a4c"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("e5b26df6-02ca-47f6-8288-35b570eb60ec"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("fe87683e-3913-4910-9f93-c4ab2ce97c62"));
        }
    }
}
