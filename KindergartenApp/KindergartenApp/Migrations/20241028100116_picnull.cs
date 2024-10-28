using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenApp.Migrations
{
    /// <inheritdoc />
    public partial class picnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Pictures",
                newName: "FilePath");

            migrationBuilder.AlterColumn<string>(
                name: "PicturePath",
                table: "KindergartenGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Pictures",
                newName: "FileName");

            migrationBuilder.AlterColumn<string>(
                name: "PicturePath",
                table: "KindergartenGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
