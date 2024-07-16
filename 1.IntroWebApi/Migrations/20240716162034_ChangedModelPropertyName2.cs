using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1.IntroWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModelPropertyName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatonDateTime",
                table: "users",
                newName: "CreationDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "users",
                newName: "CreatonDateTime");
        }
    }
}
