using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class CouchetteM2MRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couchettes_Rooms_RoomId",
                table: "Couchettes");

            migrationBuilder.DropIndex(
                name: "IX_Couchettes_RoomId",
                table: "Couchettes");

            migrationBuilder.CreateTable(
                name: "RoomСouchette",
                columns: table => new
                {
                    RoomsId = table.Column<int>(type: "integer", nullable: false),
                    СouchettesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomСouchette", x => new { x.RoomsId, x.СouchettesId });
                    table.ForeignKey(
                        name: "FK_RoomСouchette_Couchettes_СouchettesId",
                        column: x => x.СouchettesId,
                        principalTable: "Couchettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomСouchette_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomСouchette_СouchettesId",
                table: "RoomСouchette",
                column: "СouchettesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomСouchette");

            migrationBuilder.CreateIndex(
                name: "IX_Couchettes_RoomId",
                table: "Couchettes",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Couchettes_Rooms_RoomId",
                table: "Couchettes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
