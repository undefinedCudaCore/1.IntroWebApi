using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _1.IntroWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("7d29a601-31d2-42de-a5ec-c56b025f0c81"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d71ffcd9-1e83-424b-b328-2d22d690f584"));

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("4a828e82-e582-490c-b519-5c5848c7e9ce"), "Los Angeles", new DateTime(2024, 7, 29, 18, 29, 41, 985, DateTimeKind.Utc).AddTicks(295), "johnnotdoe@notexample.notcom", "JohnNotDoe" },
                    { new Guid("52af4914-a8f7-4650-bc5b-837da60095ae"), "New York", new DateTime(2024, 7, 29, 18, 29, 41, 985, DateTimeKind.Utc).AddTicks(280), "johndoe@example.com", "JohnDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("4a828e82-e582-490c-b519-5c5848c7e9ce"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("52af4914-a8f7-4650-bc5b-837da60095ae"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("7d29a601-31d2-42de-a5ec-c56b025f0c81"), "Los Angeles", new DateTime(2024, 7, 16, 16, 28, 39, 401, DateTimeKind.Utc).AddTicks(5921), "johnnotdoe@notexample.notcom", "JohnNotDoe" },
                    { new Guid("d71ffcd9-1e83-424b-b328-2d22d690f584"), "New York", new DateTime(2024, 7, 16, 16, 28, 39, 401, DateTimeKind.Utc).AddTicks(5913), "johndoe@example.com", "JohnDoe" }
                });
        }
    }
}
