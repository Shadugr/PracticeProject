using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class Seed4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "714171e5-3745-458c-8f44-8e79336af3a5", new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9000), "user1@gmail.com", false, true, false, null, "test", null, null, null, "380123456789", false, "fb64b289-6062-40c4-9b74-0fda42368374", "user1", false, null },
                    { "2", 0, "bd254aab-c411-45b4-9f8a-41fb0d3465bc", new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9091), "user2@gmail.com", false, true, false, null, "test", null, null, null, "380987654321", false, "c614d5df-187a-4af7-af95-cedc8758f5e0", "user2", false, null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Location", "Price", "Title", "UserId", "ViewNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9102), "description1", true, "location1", 100000, "title1", "1", 1 },
                    { 2, new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9107), "description2", true, "location2", 200000, "title2", "1", 1 },
                    { 3, new DateTime(2023, 5, 27, 15, 54, 35, 872, DateTimeKind.Local).AddTicks(9112), "description3", true, "location3", 300000, "title3", "2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "Id", "AdvertId", "BuildingAge", "Floor", "Square", "Storey" },
                values: new object[,]
                {
                    { 1, 1, 5, 1, 50, 5 },
                    { 2, 2, 5, 2, 30, 5 }
                });

            migrationBuilder.InsertData(
                table: "Lands",
                columns: new[] { "Id", "AdvertId", "Area", "AreaDimension", "TypeOfLand" },
                values: new object[] { 1, 3, 100, (short)100, "type1" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AdvertId", "PathToFile" },
                values: new object[,]
                {
                    { 1, 1, "path1" },
                    { 2, 2, "path1" },
                    { 3, 3, "path1" }
                });
        }
    }
}
