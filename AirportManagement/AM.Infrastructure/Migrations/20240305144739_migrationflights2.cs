using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationflights2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_flightsFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_passengersPasswordNumber",
                table: "FlightPassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_passengersPasswordNumber",
                table: "Reservation",
                newName: "IX_Reservation_passengersPasswordNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                columns: new[] { "flightsFlightId", "passengersPasswordNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Flights_flightsFlightId",
                table: "Reservation",
                column: "flightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Passengers_passengersPasswordNumber",
                table: "Reservation",
                column: "passengersPasswordNumber",
                principalTable: "Passengers",
                principalColumn: "PasswordNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Flights_flightsFlightId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Passengers_passengersPasswordNumber",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "FlightPassenger");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_passengersPasswordNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_passengersPasswordNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsFlightId", "passengersPasswordNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_flightsFlightId",
                table: "FlightPassenger",
                column: "flightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_passengersPasswordNumber",
                table: "FlightPassenger",
                column: "passengersPasswordNumber",
                principalTable: "Passengers",
                principalColumn: "PasswordNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
