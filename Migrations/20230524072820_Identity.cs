using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProject.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Adverts_advert_id",
                table: "Lands");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Adverts_advert_id",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "path_to_file",
                table: "Photos",
                newName: "PathToFile");

            migrationBuilder.RenameColumn(
                name: "advert_id",
                table: "Photos",
                newName: "AdvertId");

            migrationBuilder.RenameColumn(
                name: "photo_id",
                table: "Photos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_advert_id",
                table: "Photos",
                newName: "IX_Photos_AdvertId");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "Lands",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "type_of_land",
                table: "Lands",
                newName: "TypeOfLand");

            migrationBuilder.RenameColumn(
                name: "area_dimension",
                table: "Lands",
                newName: "AreaDimension");

            migrationBuilder.RenameColumn(
                name: "advert_id",
                table: "Lands",
                newName: "AdvertId");

            migrationBuilder.RenameColumn(
                name: "land_id",
                table: "Lands",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Lands_advert_id",
                table: "Lands",
                newName: "IX_Lands_AdvertId");

            migrationBuilder.RenameColumn(
                name: "storey",
                table: "Flats",
                newName: "Storey");

            migrationBuilder.RenameColumn(
                name: "square",
                table: "Flats",
                newName: "Square");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "Flats",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "building_age",
                table: "Flats",
                newName: "BuildingAge");

            migrationBuilder.RenameColumn(
                name: "flat_id",
                table: "Flats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "AspNetUsers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Adverts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Adverts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Adverts",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Adverts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "view_number",
                table: "Adverts",
                newName: "ViewNumber");

            migrationBuilder.RenameColumn(
                name: "path_to_property",
                table: "Adverts",
                newName: "PathToProperty");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Adverts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Adverts",
                newName: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Adverts_AdvertId",
                table: "Lands",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Adverts_AdvertId",
                table: "Photos",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Adverts_AdvertId",
                table: "Lands");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Adverts_AdvertId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "PathToFile",
                table: "Photos",
                newName: "path_to_file");

            migrationBuilder.RenameColumn(
                name: "AdvertId",
                table: "Photos",
                newName: "advert_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Photos",
                newName: "photo_id");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AdvertId",
                table: "Photos",
                newName: "IX_Photos_advert_id");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Lands",
                newName: "area");

            migrationBuilder.RenameColumn(
                name: "TypeOfLand",
                table: "Lands",
                newName: "type_of_land");

            migrationBuilder.RenameColumn(
                name: "AreaDimension",
                table: "Lands",
                newName: "area_dimension");

            migrationBuilder.RenameColumn(
                name: "AdvertId",
                table: "Lands",
                newName: "advert_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lands",
                newName: "land_id");

            migrationBuilder.RenameIndex(
                name: "IX_Lands_AdvertId",
                table: "Lands",
                newName: "IX_Lands_advert_id");

            migrationBuilder.RenameColumn(
                name: "Storey",
                table: "Flats",
                newName: "storey");

            migrationBuilder.RenameColumn(
                name: "Square",
                table: "Flats",
                newName: "square");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Flats",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "BuildingAge",
                table: "Flats",
                newName: "building_age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flats",
                newName: "flat_id");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AspNetUsers",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Adverts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Adverts",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Adverts",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Adverts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ViewNumber",
                table: "Adverts",
                newName: "view_number");

            migrationBuilder.RenameColumn(
                name: "PathToProperty",
                table: "Adverts",
                newName: "path_to_property");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Adverts",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Adverts",
                newName: "created_at");

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Adverts_advert_id",
                table: "Lands",
                column: "advert_id",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Adverts_advert_id",
                table: "Photos",
                column: "advert_id",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
