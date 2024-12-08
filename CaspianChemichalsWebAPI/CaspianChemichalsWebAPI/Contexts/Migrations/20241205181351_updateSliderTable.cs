using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaspianChemichalsWebAPI.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class updateSliderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sliders");
        }
    }
}
