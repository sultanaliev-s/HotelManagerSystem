using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class CouchetteM2MRoomsRemoveIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouchetteId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Couchettes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CouchetteId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Couchettes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
