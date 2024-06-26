using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BranchesLocatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class fourthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Branches",
                newName: "Base64Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Base64Image",
                table: "Branches",
                newName: "ImageUrl");
        }
    }
}
