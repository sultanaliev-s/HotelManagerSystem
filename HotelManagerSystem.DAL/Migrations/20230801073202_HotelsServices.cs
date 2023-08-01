using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class HotelsServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServises_Hotels_HotelId",
                table: "HotelsServises");

            migrationBuilder.DropIndex(
                name: "IX_HotelsServises_HotelId",
                table: "HotelsServises");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelsServises");

            migrationBuilder.AddColumn<int>(
                name: "HotelServiceId",
                table: "HotelsServices2",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServices2_HotelServiceId",
                table: "HotelsServices2",
                column: "HotelServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices2_Hotels_HotelId",
                table: "HotelsServices2",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServices2_HotelsServises_HotelServiceId",
                table: "HotelsServices2",
                column: "HotelServiceId",
                principalTable: "HotelsServises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices2_Hotels_HotelId",
                table: "HotelsServices2");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices2_HotelsServises_HotelServiceId",
                table: "HotelsServices2");

            migrationBuilder.DropIndex(
                name: "IX_HotelsServices2_HotelServiceId",
                table: "HotelsServices2");

            migrationBuilder.DropColumn(
                name: "HotelServiceId",
                table: "HotelsServices2");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelsServises",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServises_HotelId",
                table: "HotelsServises",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServises_Hotels_HotelId",
                table: "HotelsServises",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
