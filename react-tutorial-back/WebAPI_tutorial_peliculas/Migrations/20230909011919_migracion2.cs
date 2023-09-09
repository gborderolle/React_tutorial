using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_tutorial_peliculas.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7094), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7098), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7098) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7100), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7101), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7102) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7102), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7105), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7105) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7106), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7278), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7279), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7282), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7283), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7284), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7286), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2ee6493-5a73-46f3-a3f2-46d1d11d7176",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d002f4aa-e8ac-4ec1-a497-dc6fab370a1e", "AQAAAAIAAYagAAAAEBY628okvokH3NcRevXOML3Lagtgr45MveA4hgcDmX6nukAvlkAcUc4qVgJDcbrcWA==", "55385dc2-20f9-40a5-837d-66ad6faf4e54", "Sr.Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0765c93-676c-4199-b7ee-d7877c471821",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec4b6993-a051-4c96-bb46-c994d8aa4444", "AQAAAAIAAYagAAAAEA5bC949hfbsCnyHXFhoUWjzPMPVMZG1YC3tx5lRB7p1OZT4YoGDp3Sf4sSqLkXp3Q==", "29e08a25-e304-4734-aac4-45ce5977b207", "Sr.Normal" });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9824), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9881), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9885), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9983), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9986), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9986) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9996), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9996) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9999), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(2), new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(2) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(5), new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(8), new DateTime(2023, 9, 8, 22, 19, 19, 472, DateTimeKind.Local).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6801), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6830), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6831), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6832), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6833), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6835), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6836), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6837), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7627), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7631), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7633), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7635), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7636), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7638), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7640), new DateTime(2023, 6, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7641), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7641) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7652), new DateTime(2023, 7, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7653), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7653) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7668), new DateTime(2023, 5, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7669), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7668) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7671), new DateTime(2003, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7672), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7671) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7676), new DateTime(1993, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7677), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7679), new DateTime(2013, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7680), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7679) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7681), new DateTime(1983, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7682), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7683), new DateTime(1983, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7684), new DateTime(2023, 9, 8, 22, 19, 19, 471, DateTimeKind.Local).AddTicks(7683) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(535), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(540), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(542), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(542) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(543), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(545), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(546), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(548), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(582), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(583), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(585), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(588), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(590), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(592), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2ee6493-5a73-46f3-a3f2-46d1d11d7176",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6a918447-ae55-41a4-bafe-8c5a66850618", "AQAAAAIAAYagAAAAEOWOPHfI51qfO0s1H3hQ/tAFuG6k3Y3isnhrmTH+bZrKRkkc/MoakXiGAlbGa3AVbA==", "79828cae-02bb-40c0-bcba-96fc231d3682", "admin@testing.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0765c93-676c-4199-b7ee-d7877c471821",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f26daae1-f9af-492b-8449-905012801675", "AQAAAAIAAYagAAAAEDEY/EXTYq1qfTWu6csLPdWpEg1N9a1nvgvYULFlIo25GJAEQm/+0/Hk70PVoaOe+g==", "6d6329d5-2d59-4599-8772-d38e4d9a46a7", "user@testing.com" });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3440), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3482), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3486), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3493), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3496), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3496) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3508), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3511), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3515), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3517), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3521), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(301), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(330), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(331) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(331), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(332), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(333) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(334), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(335), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(335) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(336), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(338), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(338) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1057), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1068), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1069), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1072), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1073), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Creation", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1075), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1077), new DateTime(2023, 6, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1078), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1086), new DateTime(2023, 7, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1087), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1089), new DateTime(2023, 5, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1090), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1089) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1091), new DateTime(2003, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1092), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1094), new DateTime(1993, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1095), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1096), new DateTime(2013, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1098), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1097) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1099), new DateTime(1983, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1100), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Creation", "Premiere", "Update" },
                values: new object[] { new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1101), new DateTime(1983, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1102), new DateTime(2023, 9, 8, 21, 54, 40, 440, DateTimeKind.Local).AddTicks(1101) });
        }
    }
}
