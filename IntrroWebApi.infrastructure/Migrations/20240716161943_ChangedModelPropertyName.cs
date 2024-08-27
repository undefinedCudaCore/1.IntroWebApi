using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModelPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatonDAteTime",
                table: "users",
                newName: "CreatonDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatonDateTime",
                table: "users",
                newName: "CreatonDAteTime");
        }
    }
}
