using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class ownerfororgainzation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OwnerLists_IdNumber",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationType",
                schema: "VRMS",
                table: "OwnerLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_IdNumber",
                schema: "VRMS",
                table: "OwnerLists",
                column: "IdNumber",
                unique: true,
                filter: "[IdNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OwnerLists_IdNumber",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropColumn(
                name: "OrganizationType",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_IdNumber",
                schema: "VRMS",
                table: "OwnerLists",
                column: "IdNumber",
                unique: true);
        }
    }
}
