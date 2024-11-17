using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CAPItegory_backend.Migrations
{
    /// <inheritdoc />
    public partial class CategoryChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
