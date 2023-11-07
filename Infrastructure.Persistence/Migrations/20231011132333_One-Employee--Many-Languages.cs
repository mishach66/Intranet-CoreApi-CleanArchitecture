using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OneEmployeeManyLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLanguage");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8175), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8167), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8013), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8116), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8171), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"),
                columns: new[] { "DateCreated", "EmployeeId" },
                values: new object[] { new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8173), null });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EmployeeId",
                table: "Languages",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Employees_EmployeeId",
                table: "Languages",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Employees_EmployeeId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_EmployeeId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Languages");

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

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 11, 16, 16, 1, 633, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguage_LanguagesId",
                table: "EmployeeLanguage",
                column: "LanguagesId");
        }
    }
}
