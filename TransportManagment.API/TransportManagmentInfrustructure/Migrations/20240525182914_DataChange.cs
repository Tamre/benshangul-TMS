using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class DataChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DataChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataChanges_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataChanges_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataChangeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataChangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnName = table.Column<int>(type: "int", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataChangeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataChangeDetails_DataChanges_DataChangeId",
                        column: x => x.DataChangeId,
                        principalTable: "DataChanges",
                        principalColumn: "Id");
                    
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_DataChangeDetails_DataChangeId",
                table: "DataChangeDetails",
                column: "DataChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataChanges_ApprovedById",
                table: "DataChanges",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataChanges_CreatedById",
                table: "DataChanges",
                column: "CreatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataChangeDetails");

            migrationBuilder.DropTable(
                name: "DataChanges");

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
