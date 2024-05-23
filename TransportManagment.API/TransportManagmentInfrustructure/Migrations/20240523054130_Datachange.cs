using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Datachange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSensitive = table.Column<bool>(type: "bit", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnName = table.Column<int>(type: "int", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationType = table.Column<int>(type: "int", nullable: false),
                    ISApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalChanges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataChanges_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataChanges_CreatedById",
                table: "DataChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataChanges_Id",
                table: "DataChanges",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataChanges");
        }
    }
}
