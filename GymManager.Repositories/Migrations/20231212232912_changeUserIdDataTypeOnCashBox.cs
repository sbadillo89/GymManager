using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class changeUserIdDataTypeOnCashBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("1bbaa9de-3c86-48be-9e68-0be97745d071"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("c4218a78-0296-428a-a317-6871cb170d61"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("dabfb2c9-b510-4cf9-86ec-b2a749e7bb55"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("eb7e7dfa-4ccd-4591-b816-ad6776abf60e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("f8043cf6-9f37-4be1-92c3-9d0f60c5e069"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa907c7a-87e4-4965-9d6d-a4670f17f231"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "CashBoxes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "InitialBalance",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "GymLocationId",
                schema: "dbo",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalBalance",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "CashBoxes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "InitialBalance",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "GymLocationId",
                schema: "dbo",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalBalance",
                schema: "dbo",
                table: "CashBoxes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "CashBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DocumentTypes",
                columns: new[] { "Id", "Active", "DeletedTimeUtc", "Description", "IsDeleted", "LastUpdateUtc", "RegistrationDate" },
                values: new object[,]
                {
                    { new Guid("1bbaa9de-3c86-48be-9e68-0be97745d071"), true, null, "PASAPORTE", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4218a78-0296-428a-a317-6871cb170d61"), true, null, "NIP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dabfb2c9-b510-4cf9-86ec-b2a749e7bb55"), true, null, "NIT", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb7e7dfa-4ccd-4591-b816-ad6776abf60e"), true, null, "TARJETA DE IDENTIDAD", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8043cf6-9f37-4be1-92c3-9d0f60c5e069"), true, null, "CEDULA DE CIUDADANIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa907c7a-87e4-4965-9d6d-a4670f17f231"), true, null, "CEDULA DE EXTRANJERIA", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
