using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class addServicesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelsServises",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HotelsServices2",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedUtc",
                table: "HotelsServices2",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "HotelsServices2",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HotelsServices2");

            migrationBuilder.DropColumn(
                name: "DeletedUtc",
                table: "HotelsServices2");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "HotelsServices2");
        }
    }
}
