using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class HotelsServicesNameing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices2_Hotels_HotelId",
                table: "HotelsServices2");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServices2_HotelsServises_HotelServiceId",
                table: "HotelsServices2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServices2",
                table: "HotelsServices2");

            migrationBuilder.RenameTable(
                name: "HotelsServices2",
                newName: "HotelsServicesRelation");

            migrationBuilder.RenameIndex(
                name: "IX_HotelsServices2_HotelServiceId",
                table: "HotelsServicesRelation",
                newName: "IX_HotelsServicesRelation_HotelServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation",
                columns: new[] { "HotelId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServicesRelation_Hotels_HotelId",
                table: "HotelsServicesRelation",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelsServicesRelation_HotelsServises_HotelServiceId",
                table: "HotelsServicesRelation",
                column: "HotelServiceId",
                principalTable: "HotelsServises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServicesRelation_Hotels_HotelId",
                table: "HotelsServicesRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelsServicesRelation_HotelsServises_HotelServiceId",
                table: "HotelsServicesRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation");

            migrationBuilder.RenameTable(
                name: "HotelsServicesRelation",
                newName: "HotelsServices2");

            migrationBuilder.RenameIndex(
                name: "IX_HotelsServicesRelation_HotelServiceId",
                table: "HotelsServices2",
                newName: "IX_HotelsServices2_HotelServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServices2",
                table: "HotelsServices2",
                columns: new[] { "HotelId", "ServiceId" });

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
    }
}
