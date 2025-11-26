using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationServer.Migrations
{
    /// <inheritdoc />
    public partial class _333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternateEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DisabilityPercentage",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DisabilityStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DisabilityType",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmergencyContactRelation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Ethnicity",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EthnicityGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SecondaryMobile",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AnnualFamilyIncome",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "AnnualFamilyIncome",
                table: "Guardians");

            migrationBuilder.RenameColumn(
                name: "FeeCategory",
                table: "Financials",
                newName: "AnnualFamilyIncome");

            migrationBuilder.AddColumn<bool>(
                name: "isTemporarySame",
                table: "PermanentAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTemporarySame",
                table: "PermanentAddresses");

            migrationBuilder.RenameColumn(
                name: "AnnualFamilyIncome",
                table: "Financials",
                newName: "FeeCategory");

            migrationBuilder.AddColumn<string>(
                name: "AlternateEmail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityPercentage",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityStatus",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisabilityType",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactRelation",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EthnicityGroup",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMobile",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnnualFamilyIncome",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnnualFamilyIncome",
                table: "Guardians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
