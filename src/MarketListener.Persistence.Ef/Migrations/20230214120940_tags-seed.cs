using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketListener.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class tagsseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Category", "Code", "CreateTime", "ModifyTime", "Name", "ParentId", "PersianName" },
                values: new object[,]
                {
                    { 9, "", "IEL-GE-8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Band Score 8", 4, "نمره ۸ آیلتس جنرال" },
                    { 10, "", "IEL-GE-7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Band Score 7", 4, "نمره ۷ آیلتس جنرال" },
                    { 11, "", "IEL-GE-6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Band Score 6", 4, "نمره ۶ آیلتس جنرال" },
                    { 12, "", "IEL-GE-5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Band Score 5", 4, "نمره ۵ آیلتس جنرال" },
                    { 21, "", "IEL-AC-SP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Speaking", 3, "مکالمه آیلتس جنرال" },
                    { 22, "", "IEL-AC-LI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Listening", 3, "شنیداری آیلتس جنرال" },
                    { 23, "", "IEL-AC-WR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Writing", 3, "نوشتاری آیلتس جنرال" },
                    { 24, "", "IEL-AC-RE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS Academic Reading", 3, "خواندنی آیلتس جنرال" },
                    { 26, "", "IEL-GE-SP", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Speaking", 4, "مکالمه آیلتس جنرال" },
                    { 27, "", "IEL-GE-LI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Listening", 4, "شنیداری آیلتس جنرال" },
                    { 28, "", "IEL-GE-WR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Writing", 4, "نوشتاری آیلتس جنرال" },
                    { 29, "", "IEL-GE-RE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IELTS General Reading", 4, "خواندنی آیلتس جنرال" },
                    { 101, "", "TRV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Travel", 1, "مسافرت" },
                    { 102, "", "GRT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Greeting", 1, "احوالپرسی" },
                    { 103, "", "EAT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eating Out", 1, "رستوران" },
                    { 104, "", "APT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Airport", 1, "فرودگاه" },
                    { 105, "", "WRK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Working", 1, "کار و مشاغل" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 105);
        }
    }
}
