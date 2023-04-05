using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "author",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    cover = table.Column<byte[]>(nullable: true),
                    issue_year = table.Column<string>(nullable: true),
                    page_count = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    annotation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "edition",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    cover = table.Column<byte[]>(nullable: true),
                    issue_year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_edition", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("2179f24b-a244-4400-827f-76a6710a7b77"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("83f16470-2fa4-4242-92d2-924594ac0a73"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("6689c7e2-ece6-47d2-a5da-adcc91159ad7"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author",
                schema: "public");

            migrationBuilder.DropTable(
                name: "book",
                schema: "public");

            migrationBuilder.DropTable(
                name: "edition",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");
        }
    }
}
