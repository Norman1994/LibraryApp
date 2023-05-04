using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class EditionCodeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameTable(
                name: "editionbook",
                newName: "editionbook",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "authorbook",
                newName: "authorbook",
                newSchema: "public");

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "edition",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "public",
                table: "user",
                columns: new[] { "user_id", "email", "first_name", "last_name", "password", "role", "username" },
                values: new object[,]
                {
                    { new Guid("679cd55c-6700-4b5b-802b-c029d1e7966d"), "dima.kulikov1993@gmail.com", "Dmitry", "Kulikov", "Dima_kulikov1993", "user", "Dima_kulikov1993" },
                    { new Guid("e5520708-fdac-47c3-b3be-e5de21187a69"), "Norman1994@mail.ru", "Dmitry", "Kazin", "Dima_kazin1994", "user", "Norman1994" },
                    { new Guid("8deb0fbd-f78c-4e63-95b4-53bb3cd76e09"), "burlis@mail.ru", "Elena", "Posypkina", "Burlis1994", "admin", "Burlis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("679cd55c-6700-4b5b-802b-c029d1e7966d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("8deb0fbd-f78c-4e63-95b4-53bb3cd76e09"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "user",
                keyColumn: "user_id",
                keyValue: new Guid("e5520708-fdac-47c3-b3be-e5de21187a69"));

            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "edition");

            migrationBuilder.RenameTable(
                name: "editionbook",
                schema: "public",
                newName: "editionbook");

            migrationBuilder.RenameTable(
                name: "authorbook",
                schema: "public",
                newName: "authorbook");

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
        }
    }
}
