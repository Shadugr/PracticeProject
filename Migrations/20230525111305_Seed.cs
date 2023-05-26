using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PathToFile",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfLand",
                table: "Lands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PathToProperty",
                table: "Adverts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "b7c0c019-14e9-402a-8609-815adea2b7b4", new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4354), "user1@gmail.com", false, true, false, null, "test", null, null, null, "380123456789", false, "6811f978-16d0-42cb-93ce-cfceaa76d5b9", "user1", false, null },
                    { "2", 0, "f36f1abc-6540-44f1-9353-c6da06206c78", new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4467), "user2@gmail.com", false, true, false, null, "test", null, null, null, "380987654321", false, "138b41a5-7f33-4336-8514-31296efe4b57", "user2", false, null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Location", "PathToProperty", "Price", "Title", "UserId", "ViewNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4482), "description1", true, "location1", "path1", 100000, "title1", "1", 1 },
                    { 2, new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4490), "description2", true, "location2", "path2", 200000, "title2", "1", 1 },
                    { 3, new DateTime(2023, 5, 25, 14, 13, 5, 146, DateTimeKind.Local).AddTicks(4498), "description3", true, "location3", "path3", 300000, "title3", "2", 1 }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PathToFile",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOfLand",
                table: "Lands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PathToProperty",
                table: "Adverts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
