using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class vehicleplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousModule",
                schema: "VRMS",
                table: "VehiclePlates",
                newName: "IssueReason");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.RenameColumn(
                name: "IssueReason",
                schema: "VRMS",
                table: "VehiclePlates",
                newName: "PreviousModule");
        }
    }
}
