using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class adddocumentTypesseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentTypes",
                columns: new[] { "Id", "Active", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("06c43ce2-be08-4b6c-ac21-6854b71d18cd"), true, null, "NIP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85ac4bd1-43ac-4af9-bc3a-4a5cd0bc677a"), true, null, "CEDULA DE EXTRANJERIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a5a7d5-6c47-46ee-bfc0-e142a0a81c44"), true, null, "PASAPORTE", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be0cb6a5-6e05-4b39-9d7f-d5c78365f3aa"), true, null, "NIT", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f07cc857-9f8d-4d8a-b8fb-8dfe8d6595ba"), true, null, "TARJETA DE IDENTIDAD", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fefef7da-d12a-49c1-82c1-b962c1d2051b"), true, null, "CEDULA DE CIUDADANIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("06c43ce2-be08-4b6c-ac21-6854b71d18cd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("85ac4bd1-43ac-4af9-bc3a-4a5cd0bc677a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("b3a5a7d5-6c47-46ee-bfc0-e142a0a81c44"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("be0cb6a5-6e05-4b39-9d7f-d5c78365f3aa"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("f07cc857-9f8d-4d8a-b8fb-8dfe8d6595ba"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("fefef7da-d12a-49c1-82c1-b962c1d2051b"));
        }
    }
}
