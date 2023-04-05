using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class AddSorokinsSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "author",
                keyColumn: "id",
                keyValue: new Guid("1e02e0a9-65bc-44c4-9374-5275301eabb9"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "book",
                keyColumn: "id",
                keyValue: new Guid("3237c832-37d8-4079-a5fa-9b0203c832b7"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "book",
                keyColumn: "id",
                keyValue: new Guid("f3d61903-99aa-45b6-a032-dda5880cd6e2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("4e3a1884-f642-40f6-96ab-4f2e286857d1"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("62be26f6-9aab-497b-88c2-fdeb796c44c2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("b1732127-0a57-438f-9102-05879865c91e"));

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
                table: "author",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("da5368d8-7225-4fb0-b7b4-9db8280aee00"), "Vladimir", "Sorokin" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "book",
                columns: new[] { "id", "annotation", "cover", "description", "issue_year", "name", "page_count", "rating" },
                values: new object[,]
                {
                    { new Guid("7b514a34-976f-4986-a0d4-dc2a82bcf9c8"), null, null, null, null, "Goluboe Salo", 0, 0 },
                    { new Guid("e4006af1-32b1-4160-9ee5-f5fe6f0d5ccd"), null, null, null, null, "Norma", 0, 0 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("b3e60163-f04a-4e7c-a9d6-2778390505bf"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("dd80e78c-d377-4a6a-8e39-4f6cb1fe98a5"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("d175d342-d1b8-4408-8262-0ee65f60208a"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
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
                table: "author",
                keyColumn: "id",
                keyValue: new Guid("da5368d8-7225-4fb0-b7b4-9db8280aee00"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "book",
                keyColumn: "id",
                keyValue: new Guid("7b514a34-976f-4986-a0d4-dc2a82bcf9c8"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "book",
                keyColumn: "id",
                keyValue: new Guid("e4006af1-32b1-4160-9ee5-f5fe6f0d5ccd"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("b3e60163-f04a-4e7c-a9d6-2778390505bf"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("d175d342-d1b8-4408-8262-0ee65f60208a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("dd80e78c-d377-4a6a-8e39-4f6cb1fe98a5"));

            migrationBuilder.InsertData(
                schema: "public",
                table: "author",
                columns: new[] { "id", "first_name", "last_name" },
                values: new object[] { new Guid("1e02e0a9-65bc-44c4-9374-5275301eabb9"), "Vladimir", "Sorokin" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "book",
                columns: new[] { "id", "annotation", "cover", "description", "issue_year", "name", "page_count", "rating" },
                values: new object[,]
                {
                    { new Guid("f3d61903-99aa-45b6-a032-dda5880cd6e2"), null, null, null, null, "Goluboe Salo", 0, 0 },
                    { new Guid("3237c832-37d8-4079-a5fa-9b0203c832b7"), null, null, null, null, "Norma", 0, 0 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("4e3a1884-f642-40f6-96ab-4f2e286857d1"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("b1732127-0a57-438f-9102-05879865c91e"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("62be26f6-9aab-497b-88c2-fdeb796c44c2"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
                });
        }
    }
}
