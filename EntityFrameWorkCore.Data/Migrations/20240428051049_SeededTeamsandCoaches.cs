using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeamsandCoaches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "coaches",
                columns: new[] { "Id", "Act_Ind", "Crtd_Date", "Crtd_User", "Del_Ind", "Lst_Crtd_Date", "Lst_Crtd_User", "Name" },
                values: new object[,]
                {
                    { new Guid("08bc3731-263b-4b4a-a2ff-e68afeb57566"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8432), "dqzjbib", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8432), "enjoigu", "npkri" },
                    { new Guid("0db84259-5269-459b-b3b1-62e790f0ac31"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8473), "nofwr q", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8474), "ytgdirb", "zaolh" },
                    { new Guid("1ffe8c20-eba2-48f4-b7e1-08e094182c1b"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8453), "lcfanjq", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8453), "xksrkyo", "ekapd" },
                    { new Guid("7c558842-d686-43bb-8b81-a8c80b355fca"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8411), "hzzlddu", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8411), "kaemaeh", "fvrun" },
                    { new Guid("88750200-9fcc-4c91-909d-969f1f421634"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8382), "rspihau", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8383), "dxqdlgi", "colmx" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Act_Ind", "Crtd_Date", "Crtd_User", "Del_Ind", "Lst_Crtd_Date", "Lst_Crtd_User", "TeamName" },
                values: new object[,]
                {
                    { new Guid("22d8ec21-457e-473f-8a25-f3d13fcfa96a"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8118), "vkcwlce", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8118), "zlurtqn", "umrcpvtbzy" },
                    { new Guid("36cb09e6-45a9-4ed9-87a3-a13f8cb82e94"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8141), "irkl oz", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8141), "ejlzldx", " efylbapra" },
                    { new Guid("6a4deaed-9420-43d0-aeb1-ebe23c8cc236"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8162), "vavvpyn", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8163), "lwecodn", "lprbe nhzj" },
                    { new Guid("97612c26-55cf-466c-98b4-924b182195df"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8012), "hjgik z", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8019), "bs xgrg", "mbvablnz p" },
                    { new Guid("ff667966-71e8-4e06-8c2c-6e723b76570e"), (short)1, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8184), "acwtvzi", (short)0, new DateTime(2024, 4, 28, 5, 10, 49, 252, DateTimeKind.Unspecified).AddTicks(8184), "rcufifh", "gbghlftmzs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("08bc3731-263b-4b4a-a2ff-e68afeb57566"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("0db84259-5269-459b-b3b1-62e790f0ac31"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("1ffe8c20-eba2-48f4-b7e1-08e094182c1b"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("7c558842-d686-43bb-8b81-a8c80b355fca"));

            migrationBuilder.DeleteData(
                table: "coaches",
                keyColumn: "Id",
                keyValue: new Guid("88750200-9fcc-4c91-909d-969f1f421634"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("22d8ec21-457e-473f-8a25-f3d13fcfa96a"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("36cb09e6-45a9-4ed9-87a3-a13f8cb82e94"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("6a4deaed-9420-43d0-aeb1-ebe23c8cc236"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("97612c26-55cf-466c-98b4-924b182195df"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("ff667966-71e8-4e06-8c2c-6e723b76570e"));

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
    }
}
