using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LanguageWithoutDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateDeleted", "DateUpdated", "DeletedBy", "EmployeeId", "LanguageName", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8175), null, null, null, null, "იტალიური", null, 0 },
                    { new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8167), null, null, null, null, "გერმანული", null, 0 },
                    { new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8013), null, null, null, null, "ქართული", null, 0 },
                    { new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8116), null, null, null, null, "ინგლისური", null, 0 },
                    { new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8171), null, null, null, null, "ფრანგული", null, 0 },
                    { new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"), null, new DateTime(2023, 10, 11, 17, 23, 33, 290, DateTimeKind.Local).AddTicks(8173), null, null, null, null, "ესპანური", null, 0 }
                });
        }
    }
}
