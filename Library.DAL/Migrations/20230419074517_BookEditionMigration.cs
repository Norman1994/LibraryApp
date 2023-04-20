using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class BookEditionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "book_id",
                schema: "public",
                table: "edition");

            migrationBuilder.RenameTable(
                name: "authorbook",
                newName: "authorbook",
                newSchema: "public");

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                schema: "public",
                table: "edition",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "editionbook",
                schema: "public",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false),
                    EditionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editionbook", x => new { x.BooksId, x.EditionsId });
                    table.ForeignKey(
                        name: "FK_editionbook_book_BooksId",
                        column: x => x.BooksId,
                        principalSchema: "public",
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_editionbook_edition_EditionsId",
                        column: x => x.EditionsId,
                        principalSchema: "public",
                        principalTable: "edition",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("4c7825cb-5034-4479-9464-70142063f413"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("685486b3-57eb-4bdc-b481-c5724a49a139"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("aeae0fb6-1a3b-4ff8-9500-54b37064364f"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_editionbook_EditionsId",
                schema: "public",
                table: "editionbook",
                column: "EditionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "editionbook",
                schema: "public");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("4c7825cb-5034-4479-9464-70142063f413"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("685486b3-57eb-4bdc-b481-c5724a49a139"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("aeae0fb6-1a3b-4ff8-9500-54b37064364f"));

            migrationBuilder.DropColumn(
                name: "publisher",
                schema: "public",
                table: "edition");

            migrationBuilder.RenameTable(
                name: "authorbook",
                schema: "public",
                newName: "authorbook");

            migrationBuilder.AddColumn<Guid>(
                name: "book_id",
                schema: "public",
                table: "edition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }
    }
}
