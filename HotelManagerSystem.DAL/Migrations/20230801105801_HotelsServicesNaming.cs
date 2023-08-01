using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class HotelsServicesNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "HotelsServicesRelation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation",
                columns: new[] { "HotelId", "HotelServiceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "HotelsServicesRelation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation",
                columns: new[] { "HotelId", "ServiceId" });
        }
    }
}
