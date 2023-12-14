using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class addCustomerDimensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipCustomers_Customers_CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers");

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

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipTypeId",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateTable(
                name: "CustomerDimensions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerDocumentNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    BodyFatPercentage = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDimensions_Customers_CustomerDocumentNumber",
                        column: x => x.CustomerDocumentNumber,
                        principalSchema: "dbo",
                        principalTable: "Customers",
                        principalColumn: "DocumentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDimensions_CustomerDocumentNumber",
                schema: "dbo",
                table: "CustomerDimensions",
                column: "CustomerDocumentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipCustomers_Customers_CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers",
                column: "CustomerDocumentNumber",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "DocumentNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembershipCustomers_Customers_CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.DropTable(
                name: "CustomerDimensions",
                schema: "dbo");

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
                table: "MembershipCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<Guid>(
                name: "MembershipTypeId",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MembershipCustomers_Customers_CustomerDocumentNumber",
                schema: "dbo",
                table: "MembershipCustomers",
                column: "CustomerDocumentNumber",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "DocumentNumber");
        }
    }
}
