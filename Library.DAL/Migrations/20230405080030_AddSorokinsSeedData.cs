using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class AddSorokinsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authorbook");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "book_id",
                schema: "public",
                table: "edition");

            migrationBuilder.CreateTable(
                name: "authorbook",
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
                table: "authorbook",
                column: "BooksId");
        }
    }
}
