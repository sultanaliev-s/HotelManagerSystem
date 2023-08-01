using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class HotelsServicesPk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HotelsServicesRelation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsServicesRelation_HotelId",
                table: "HotelsServicesRelation",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation");

            migrationBuilder.DropIndex(
                name: "IX_HotelsServicesRelation_HotelId",
                table: "HotelsServicesRelation");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HotelsServicesRelation",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelsServicesRelation",
                table: "HotelsServicesRelation",
                columns: new[] { "HotelId", "HotelServiceId" });
        }
    }
}
