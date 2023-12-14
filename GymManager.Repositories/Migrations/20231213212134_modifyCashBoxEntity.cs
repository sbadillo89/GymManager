using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class modifyCashBoxEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("6f825447-40b6-42be-820e-17cf90a51b5d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("719b8856-b6fd-4b0d-b7fc-401de9467867"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("7cb53ed3-2968-406d-85f2-45d88fa0faec"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("d73db31d-2d72-44bb-8d73-301686e9a052"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("e705a5a6-fb12-41cd-a0e6-4288681400b3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa799a45-41b6-47f7-a960-b64c03d9082e"));

            migrationBuilder.RenameColumn(
                name: "FinalBalance",
                schema: "dbo",
                table: "CashBoxes",
                newName: "FinalUserBalance");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "CashBoxes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<decimal>(
                name: "Discrepancy",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalSystemBalance",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 5);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discrepancy",
                schema: "dbo",
                table: "CashBoxes");

            migrationBuilder.DropColumn(
                name: "FinalSystemBalance",
                schema: "dbo",
                table: "CashBoxes");

            migrationBuilder.RenameColumn(
                name: "FinalUserBalance",
                schema: "dbo",
                table: "CashBoxes",
                newName: "FinalBalance");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "CashBoxes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentTypes",
                columns: new[] { "Id", "Active", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("6f825447-40b6-42be-820e-17cf90a51b5d"), true, null, "NIP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("719b8856-b6fd-4b0d-b7fc-401de9467867"), true, null, "NIT", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cb53ed3-2968-406d-85f2-45d88fa0faec"), true, null, "PASAPORTE", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d73db31d-2d72-44bb-8d73-301686e9a052"), true, null, "CEDULA DE EXTRANJERIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e705a5a6-fb12-41cd-a0e6-4288681400b3"), true, null, "TARJETA DE IDENTIDAD", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa799a45-41b6-47f7-a960-b64c03d9082e"), true, null, "CEDULA DE CIUDADANIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
