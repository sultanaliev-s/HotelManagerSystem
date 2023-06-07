using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagerSystem.DAL.Migrations
{
    public partial class hotelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "RoomsTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "RoomsReservations");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "HotelsTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "HotelsServises");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "HotelsFotos");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "HotelsCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Couchettes");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "ClientsReviews");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UpdatedUtc",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "RoomsTypes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "RoomsReservations",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Rooms",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "HotelsTypes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "HotelsServises",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "HotelsFotos",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "HotelsCategories",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Hotels",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "ErrorLogs",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Countries",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Couchettes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "ClientsReviews",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Cities",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "Addresses",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomsTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomsReservations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HotelsTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HotelsServises",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HotelsFotos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HotelsCategories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Hotels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "Hotels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ErrorLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Countries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Couchettes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ClientsReviews",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Hotels_HotelId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_HotelId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RoomsTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RoomsReservations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HotelsTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HotelsServises");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HotelsFotos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HotelsCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Couchettes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ClientsReviews");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "RoomsTypes",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "RoomsReservations",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Rooms",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "HotelsTypes",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "HotelsServises",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "HotelsFotos",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "HotelsCategories",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Hotels",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ErrorLogs",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Countries",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Couchettes",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "ClientsReviews",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Cities",
                newName: "CreatedUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Addresses",
                newName: "CreatedUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "RoomsTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "RoomsReservations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Rooms",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "HotelsTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "HotelsServises",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "HotelsFotos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "HotelsCategories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Hotels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "ErrorLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Countries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Couchettes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "ClientsReviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Cities",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedUtc",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
