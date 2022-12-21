using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketListener.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class addauditingentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Words",
                type: "datetime2(1)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Words",
                type: "datetime2(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Tags",
                type: "datetime2(1)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Tags",
                type: "datetime2(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Questions",
                type: "datetime2(1)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Questions",
                type: "datetime2(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Meanings",
                type: "datetime2(1)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Meanings",
                type: "datetime2(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "MeaningExamples",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "MeaningExamples",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Answers",
                type: "datetime2(1)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Answers",
                type: "datetime2(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "248f2486-49af-4a78-8008-b4b44533e940", null, "User", "USER" },
                    { "7040fa1d-be02-427f-8041-869791262152", null, "Administrator", "ADMINISTRATOR" },
                    { "ca046c71-fca8-439d-9583-80d919c6d738", null, "Supporter", "SUPPORTER" }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "248f2486-49af-4a78-8008-b4b44533e940");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7040fa1d-be02-427f-8041-869791262152");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca046c71-fca8-439d-9583-80d919c6d738");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Meanings");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Meanings");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "MeaningExamples");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "MeaningExamples");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Answers");
        }
    }
}
