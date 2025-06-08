using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranTinh_3282_W3.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Spec",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spec",
                table: "Products");
        }
    }
}
