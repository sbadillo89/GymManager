using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class addImageToGymEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("35c28594-c9df-438f-bf1e-0444e82c054c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("3acde047-3348-4c32-a4b6-b24d4e367143"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("44611060-af8b-4522-89bc-52d7cf2e62c9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("7d3f51ae-7e07-44dc-9547-aecb47042c65"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("9cbb2b41-5bbe-42c1-8bfc-0ce6796ffa5d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("a72fc177-ced2-47fd-9300-cd3f5550db30"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                schema: "dbo",
                table: "Gyms",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentTypes",
                columns: new[] { "Id", "Active", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("13dc3278-488e-4ca5-afdf-56079a30c05b"), true, null, "TARJETA DE IDENTIDAD", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e9c59c3-6fd4-4190-8acf-21d43461923f"), true, null, "CEDULA DE EXTRANJERIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("334b8a66-d555-455c-a476-e3ee677e1240"), true, null, "CEDULA DE CIUDADANIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("363acc6f-8f88-4ba4-9a7a-884a8c576a8c"), true, null, "NIT", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9560e060-02e5-4dba-837c-c3f46c6750dc"), true, null, "PASAPORTE", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3154f30-612d-499f-aa0c-f6c5d9dced12"), true, null, "NIP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("13dc3278-488e-4ca5-afdf-56079a30c05b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("2e9c59c3-6fd4-4190-8acf-21d43461923f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("334b8a66-d555-455c-a476-e3ee677e1240"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("363acc6f-8f88-4ba4-9a7a-884a8c576a8c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("9560e060-02e5-4dba-837c-c3f46c6750dc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("b3154f30-612d-499f-aa0c-f6c5d9dced12"));

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "dbo",
                table: "Gyms");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentTypes",
                columns: new[] { "Id", "Active", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("35c28594-c9df-438f-bf1e-0444e82c054c"), true, null, "TARJETA DE IDENTIDAD", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3acde047-3348-4c32-a4b6-b24d4e367143"), true, null, "PASAPORTE", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44611060-af8b-4522-89bc-52d7cf2e62c9"), true, null, "CEDULA DE CIUDADANIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d3f51ae-7e07-44dc-9547-aecb47042c65"), true, null, "CEDULA DE EXTRANJERIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cbb2b41-5bbe-42c1-8bfc-0ce6796ffa5d"), true, null, "NIP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a72fc177-ced2-47fd-9300-cd3f5550db30"), true, null, "NIT", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
