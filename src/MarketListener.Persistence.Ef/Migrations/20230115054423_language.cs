using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketListener.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Meanings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2(1)", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_LanguageId",
                table: "Meanings",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meanings_Languages_LanguageId",
                table: "Meanings",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meanings_Languages_LanguageId",
                table: "Meanings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Meanings_LanguageId",
                table: "Meanings");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Meanings");
        }
    }
}
