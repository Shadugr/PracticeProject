using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class Seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 26, 17, 4, 19, 715, DateTimeKind.Local).AddTicks(1857));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "b7c0c019-14e9-402a-8609-815adea2b7b4", new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4354), "6811f978-16d0-42cb-93ce-cfceaa76d5b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "f36f1abc-6540-44f1-9353-c6da06206c78", new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4467), "138b41a5-7f33-4336-8514-31296efe4b57" });
        }
    }
}
