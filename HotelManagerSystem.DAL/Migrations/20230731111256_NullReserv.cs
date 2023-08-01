using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class NullReserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomsReservations_RoomId",
                table: "RoomsReservations");

            migrationBuilder.DropColumn(
                name: "RoomReservationId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservations_RoomId",
                table: "RoomsReservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomsReservations_RoomId",
                table: "RoomsReservations");

            migrationBuilder.AddColumn<int>(
                name: "RoomReservationId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservations_RoomId",
                table: "RoomsReservations",
                column: "RoomId",
                unique: true);
        }
    }
}
