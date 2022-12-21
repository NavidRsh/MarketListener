using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketListener.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class seedtags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Category", "Name", "ParentId", "PersianName" },
                values: new object[] { 1, "", "General", null, "عمومی" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
