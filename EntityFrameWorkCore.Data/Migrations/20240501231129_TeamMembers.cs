using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TeamMembers",
                table: "teams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TeamMembers",
                table: "teams");

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
    }
}
