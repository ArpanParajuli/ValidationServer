using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationServer.Migrations
{
    /// <inheritdoc />
    public partial class fixedallbugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AcademicEnrollments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Students",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecondaryInfos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Scholarships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OtherInformations",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Interests",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Guardians",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Financials",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Fees",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Ethnicities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Emergencies",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Documents",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Disabilities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Citizenships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Banks",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Awards",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Addresses",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AcademicHistorys",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AcademicEnrollments",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
