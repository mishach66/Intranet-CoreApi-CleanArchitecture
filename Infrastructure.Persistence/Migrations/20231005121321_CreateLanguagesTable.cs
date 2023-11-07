using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateLanguagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguage",
                columns: table => new
                {
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguage", x => new { x.EmployeesId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_EmployeeLanguage_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateDeleted", "DateUpdated", "DeletedBy", "LanguageName", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1534), null, null, null, "იტალიური", null, 0 },
                    { new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1528), null, null, null, "გერმანული", null, 0 },
                    { new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1426), null, null, null, "ქართული", null, 0 },
                    { new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1494), null, null, null, "ინგლისური", null, 0 },
                    { new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1530), null, null, null, "ფრანგული", null, 0 },
                    { new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"), null, new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1533), null, null, null, "ესპანური", null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguage_LanguagesId",
                table: "EmployeeLanguage",
                column: "LanguagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLanguage");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Employees",
                type: "int",
                nullable: true);
        }
    }
}
