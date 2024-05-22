using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class vehicleownergroupowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerGroup",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.AddColumn<int>(
                name: "OwnerGroup",
                schema: "VRMS",
                table: "OwnerLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerGroup",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.AddColumn<int>(
                name: "OwnerGroup",
                schema: "VRMS",
                table: "VehicleOwners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
