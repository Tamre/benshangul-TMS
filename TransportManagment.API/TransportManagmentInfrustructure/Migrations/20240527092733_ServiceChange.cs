using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class ServiceChange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                schema: "VRMS",
                table: "ServiceChanges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "VRMS",
                table: "ServiceChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "DataChanges",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DataChangeDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DataChangeDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceChanges_Users_ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "ApprovedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceChanges_Users_ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropIndex(
                name: "IX_ServiceChanges_ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "DataChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DataChangeDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DataChangeDetails",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
