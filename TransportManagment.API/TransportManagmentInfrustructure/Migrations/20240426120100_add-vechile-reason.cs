using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class addvechilereason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuationLists_ValuationReason_ValuationReasonId",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationReason_Users_CreatedById",
                table: "ValuationReason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValuationReason",
                table: "ValuationReason");

            migrationBuilder.RenameTable(
                name: "ValuationReason",
                newName: "ValuationReasons");

            migrationBuilder.RenameIndex(
                name: "IX_ValuationReason_CreatedById",
                table: "ValuationReasons",
                newName: "IX_ValuationReasons_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValuationReasons",
                table: "ValuationReasons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationLists_ValuationReasons_ValuationReasonId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ValuationReasonId",
                principalTable: "ValuationReasons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationReasons_Users_CreatedById",
                table: "ValuationReasons",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValuationLists_ValuationReasons_ValuationReasonId",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationReasons_Users_CreatedById",
                table: "ValuationReasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValuationReasons",
                table: "ValuationReasons");

            migrationBuilder.RenameTable(
                name: "ValuationReasons",
                newName: "ValuationReason");

            migrationBuilder.RenameIndex(
                name: "IX_ValuationReasons_CreatedById",
                table: "ValuationReason",
                newName: "IX_ValuationReason_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValuationReason",
                table: "ValuationReason",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationLists_ValuationReason_ValuationReasonId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ValuationReasonId",
                principalTable: "ValuationReason",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationReason_Users_CreatedById",
                table: "ValuationReason",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
