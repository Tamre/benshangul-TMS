using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class DataChangeDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataChangeDetails_CreatedById",
                table: "DataChangeDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DataChangeDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DataChangeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DataChangeDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataChangeDetails_CreatedById",
                table: "DataChangeDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DataChangeDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DataChangeDetails");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "DataChangeDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);
        }
    }
}
