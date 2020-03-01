using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManager.Data.Migrations
{
    public partial class AddClientsReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientsReservations",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ReservationId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsReservations", x => new { x.ClientId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ClientsReservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsReservations_ReservationId",
                table: "ClientsReservations",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsReservations");

            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
