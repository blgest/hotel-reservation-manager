using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationManager.Data.Migrations
{
    public partial class ClientRenamedProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Clients",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ThirdName",
                table: "Clients",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "Telephone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "ThirdName");
        }
    }
}
