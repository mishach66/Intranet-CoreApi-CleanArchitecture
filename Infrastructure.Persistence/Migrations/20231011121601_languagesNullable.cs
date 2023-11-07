using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class languagesNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9e0a3381-f066-4bb9-bf6c-c3d8bb3331d9"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"),
                column: "DateCreated",
                value: new DateTime(2023, 10, 5, 16, 13, 21, 77, DateTimeKind.Local).AddTicks(1533));
        }
    }
}
