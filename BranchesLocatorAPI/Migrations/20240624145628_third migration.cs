using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BranchesLocatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plz",
                table: "Branches",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "Ort",
                table: "Branches",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Kanton",
                table: "Branches",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Firma",
                table: "Branches",
                newName: "Canton");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Branches",
                newName: "Plz");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Branches",
                newName: "Ort");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Branches",
                newName: "Kanton");

            migrationBuilder.RenameColumn(
                name: "Canton",
                table: "Branches",
                newName: "Firma");
        }
    }
}
