using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketListener.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class seedtags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Tags",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "GNR");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Category", "Code", "CreateTime", "ModifyTime", "Name", "ParentId", "PersianName" },
                values: new object[,]
                {
                    { 2, "", "IEL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS", null, "آزمون آیلتس" },
                    { 3, "", "IEL-AC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic", 2, "آزمون آیلتس" },
                    { 4, "", "IEL-GNR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General", 2, "آزمون آیلتس" },
                    { 5, "", "IEL-AC-8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Band Score 8", 3, "نمره ۸ آیلتس" },
                    { 6, "", "IEL-AC-7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Band Score 7", 3, "نمره ۷ آیلتس" },
                    { 7, "", "IEL-AC-6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Band Score 6", 3, "نمره ۶ آیلتس" },
                    { 8, "", "IEL-AC-5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Band Score 5", 3, "نمره ۵ آیلتس" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Tags");
        }
    }
}
