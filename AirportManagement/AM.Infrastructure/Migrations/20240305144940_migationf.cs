using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migationf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_myPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_myPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "myPlanes",
                principalColumn: "PlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_myPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_myPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "myPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
