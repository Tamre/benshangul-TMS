using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class VehicleListSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VehicleLists",
                newName: "VehicleLists",
                newSchema: "VRMS");

            migrationBuilder.RenameTable(
                name: "ValuationReasons",
                newName: "ValuationReasons",
                newSchema: "VRMS");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VehicleLists",
                schema: "VRMS",
                newName: "VehicleLists");

            migrationBuilder.RenameTable(
                name: "ValuationReasons",
                schema: "VRMS",
                newName: "ValuationReasons");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
