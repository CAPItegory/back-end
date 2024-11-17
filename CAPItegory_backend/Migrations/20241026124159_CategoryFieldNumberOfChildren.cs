using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAPItegory_backend.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFieldNumberOfChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Category");
        }
    }
}
