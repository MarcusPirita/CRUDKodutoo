using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenCRUD.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Groupname",
                table: "Kindergartens",
                newName: "GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Kindergartens",
                newName: "Groupname");
        }
    }
}
