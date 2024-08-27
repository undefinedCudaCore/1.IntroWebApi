using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntroWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAvatarForUser : Migration
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

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

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
                columns: new[] { "Id", "City", "CreationDateTime", "Email", "FileData", "FileName", "UserName" },
                values: new object[,]
                {
                    { new Guid("677440e5-43cd-4d8d-b459-dfc53ec0f728"), "Los Angeles", new DateTime(2024, 8, 7, 15, 25, 29, 650, DateTimeKind.Utc).AddTicks(3391), "johnnotdoe@notexample.notcom", null, null, "JohnNotDoe" },
                    { new Guid("e1c591d1-4856-42fe-bd7f-f6a54ed34315"), "New York", new DateTime(2024, 8, 7, 15, 25, 29, 650, DateTimeKind.Utc).AddTicks(3377), "johndoe@example.com", null, null, "JohnDoe" }
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
                keyValue: new Guid("677440e5-43cd-4d8d-b459-dfc53ec0f728"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("e1c591d1-4856-42fe-bd7f-f6a54ed34315"));

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "users");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "users");

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
