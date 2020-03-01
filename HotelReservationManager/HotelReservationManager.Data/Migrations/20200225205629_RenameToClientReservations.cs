using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManager.Data.Migrations
{
    public partial class RenameToClientReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsReservations");

            migrationBuilder.CreateTable(
                name: "ClientReservations",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ReservationId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientReservations", x => new { x.ClientId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ClientReservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientReservations_ReservationId",
                table: "ClientReservations",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientReservations");

            migrationBuilder.CreateTable(
                name: "ClientsReservations",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
    }
}
