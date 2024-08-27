using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedInitialUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("7d29a601-31d2-42de-a5ec-c56b025f0c81"), "Los Angeles", new DateTime(2024, 7, 16, 16, 28, 39, 401, DateTimeKind.Utc).AddTicks(5921), "johnnotdoe@notexample.notcom", "JohnNotDoe" },
                    { new Guid("d71ffcd9-1e83-424b-b328-2d22d690f584"), "New York", new DateTime(2024, 7, 16, 16, 28, 39, 401, DateTimeKind.Utc).AddTicks(5913), "johndoe@example.com", "JohnDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("7d29a601-31d2-42de-a5ec-c56b025f0c81"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d71ffcd9-1e83-424b-b328-2d22d690f584"));
        }
    }
}
