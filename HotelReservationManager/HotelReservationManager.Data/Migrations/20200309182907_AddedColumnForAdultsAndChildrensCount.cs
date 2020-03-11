using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManager.Data.Migrations
{
    public partial class AddedColumnForAdultsAndChildrensCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFree",
                table: "Rooms",
                newName: "IsFree");

            migrationBuilder.AddColumn<int>(
                name: "AdultsCount",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildrensCount",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultsCount",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ChildrensCount",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "IsFree",
                table: "Rooms",
                newName: "isFree");
        }
    }
}
