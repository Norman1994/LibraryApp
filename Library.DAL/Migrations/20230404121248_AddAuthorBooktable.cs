using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class AddAuthorBooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("2179f24b-a244-4400-827f-76a6710a7b77"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("6689c7e2-ece6-47d2-a5da-adcc91159ad7"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("83f16470-2fa4-4242-92d2-924594ac0a73"));

            migrationBuilder.CreateTable(
                name: "authorbook",
                schema: "public",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorbook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_authorbook_author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalSchema: "public",
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorbook_book_BooksId",
                        column: x => x.BooksId,
                        principalSchema: "public",
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("b0ae60fa-87b2-451a-be36-54fd3552a0df"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("c9ecb1a5-729b-4feb-a028-e405d79573ad"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("084f75cd-70ad-413d-8e20-64321e46a825"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_authorbook_BooksId",
                schema: "public",
                table: "authorbook",
                column: "BooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authorbook",
                schema: "public");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("084f75cd-70ad-413d-8e20-64321e46a825"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("b0ae60fa-87b2-451a-be36-54fd3552a0df"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("c9ecb1a5-729b-4feb-a028-e405d79573ad"));

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
    }
}
