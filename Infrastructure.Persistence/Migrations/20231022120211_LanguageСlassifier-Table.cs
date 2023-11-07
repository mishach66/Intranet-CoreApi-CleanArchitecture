using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LanguageСlassifierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "Languages");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageСlassifierId",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguageСlassifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LanguageСlassifiers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LanguageСlassifiers",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateDeleted", "DateUpdated", "DeletedBy", "LanguageName", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { new Guid("69b476fa-45bb-4046-bcf1-8eb975dc6158"), null, new DateTime(2023, 10, 22, 16, 2, 11, 428, DateTimeKind.Local).AddTicks(7038), null, null, null, "იტალიური", null, 0 },
                    { new Guid("7bff9ed9-0226-4f22-b105-03d3bd13f328"), null, new DateTime(2023, 10, 22, 16, 2, 11, 428, DateTimeKind.Local).AddTicks(7031), null, null, null, "გერმანული", null, 0 },
                    { new Guid("c47e86d8-87c7-413f-b569-19c53b3e45e6"), null, new DateTime(2023, 10, 22, 16, 2, 11, 428, DateTimeKind.Local).AddTicks(6963), null, null, null, "ინგლისური", null, 0 },
                    { new Guid("d18fdd15-d0ca-43cc-bbf1-1847fd50f2ce"), null, new DateTime(2023, 10, 22, 16, 2, 11, 428, DateTimeKind.Local).AddTicks(7034), null, null, null, "ფრანგული", null, 0 },
                    { new Guid("f9ffedab-9141-4595-8c0e-59fbaebe5511"), null, new DateTime(2023, 10, 22, 16, 2, 11, 428, DateTimeKind.Local).AddTicks(7036), null, null, null, "ესპანური", null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageСlassifierId",
                table: "Languages",
                column: "LanguageСlassifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageСlassifiers_LanguageСlassifierId",
                table: "Languages",
                column: "LanguageСlassifierId",
                principalTable: "LanguageСlassifiers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageСlassifiers_LanguageСlassifierId",
                table: "Languages");

            migrationBuilder.DropTable(
                name: "LanguageСlassifiers");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageСlassifierId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageСlassifierId",
                table: "Languages");

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
