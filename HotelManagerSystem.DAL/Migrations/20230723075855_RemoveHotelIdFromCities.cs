using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class RemoveHotelIdFromCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Hotels_HotelId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_HotelId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Cities");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_cityId",
                table: "Hotels",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Cities_cityId",
                table: "Hotels",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Cities_cityId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_cityId",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_HotelId",
                table: "Cities",
                column: "HotelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Hotels_HotelId",
                table: "Cities",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
