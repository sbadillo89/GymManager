using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManager.Repositories.Migrations
{
    public partial class addentitybase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "dbo",
                table: "Gyms",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                schema: "dbo",
                table: "GymLocations",
                newName: "RegistrationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "TransactionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "TransactionTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "TransactionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "TransactionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "MembershipTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipTypeChanges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipTypeChanges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipTypeChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "MembershipTypeChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "Gyms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Gyms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Gyms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Gyms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "GymLocations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "GymLocations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "GymLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "DocumentTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "DocumentTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "CustomerChanges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "CustomerChanges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "CustomerChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "CustomerChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "CashBoxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "CashBoxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipTypeChanges");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipTypeChanges");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipTypeChanges");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "MembershipTypeChanges");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "MembershipCustomers");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "GymLocations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "GymLocations");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "GymLocations");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "CustomerChanges");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "CustomerChanges");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "CustomerChanges");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "CustomerChanges");

            migrationBuilder.DropColumn(
                name: "DeletedTimeUtc",
                schema: "dbo",
                table: "CashBoxes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "CashBoxes");

            migrationBuilder.DropColumn(
                name: "LastUpdateUtc",
                schema: "dbo",
                table: "CashBoxes");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "Gyms",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "GymLocations",
                newName: "CreationDate");
        }
    }
}
