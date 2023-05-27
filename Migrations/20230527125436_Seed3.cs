using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class Seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToProperty",
                table: "Adverts");

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "714171e5-3745-458c-8f44-8e79336af3a5", new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9000), "fb64b289-6062-40c4-9b74-0fda42368374" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "bd254aab-c411-45b4-9f8a-41fb0d3465bc", new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9091), "c614d5df-187a-4af7-af95-cedc8758f5e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToProperty",
                table: "Adverts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PathToProperty" },
                values: new object[] { new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1839), "path1" });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PathToProperty" },
                values: new object[] { new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1849), "path2" });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PathToProperty" },
                values: new object[] { new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1857), "path3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "2a483479-22d2-4b11-914f-7bf2f2af2873", new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1728), "8ebdece3-9b20-47e7-87b8-418d1200fef4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "6baa5a26-c53a-4e75-8cb3-cb364f6bfa72", new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1818), "c96e8b5b-ecfe-4cc0-b115-407e574e2fc8" });
        }
    }
}
