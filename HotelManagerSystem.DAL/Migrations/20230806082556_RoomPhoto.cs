using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class RoomPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PhotoId",
                table: "Rooms",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelsFotos_PhotoId",
                table: "Rooms",
                column: "PhotoId",
                principalTable: "HotelsFotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelsFotos_PhotoId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PhotoId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Rooms");
        }
    }
}
