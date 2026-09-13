using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_3Tir.Migrations
{
    /// <inheritdoc />
    public partial class Manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Departments");
        }
    }
}
