using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationServer.Migrations
{
    /// <inheritdoc />
    public partial class baseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Students",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SecondaryInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SecondaryInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SecondaryInfos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "SecondaryInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SecondaryInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "SecondaryInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecondaryInfos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SecondaryInfos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "SecondaryInfos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Scholarships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Scholarships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Scholarships",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Scholarships",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Scholarships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Scholarships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Scholarships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Scholarships",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Scholarships",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OtherInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "OtherInformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "OtherInformations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "OtherInformations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OtherInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "OtherInformations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OtherInformations",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OtherInformations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "OtherInformations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Interests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Interests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Interests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Interests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Interests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Interests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Interests",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Interests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Interests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Guardians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Guardians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Guardians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Guardians",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Guardians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Guardians",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Financials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Financials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Financials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Financials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Financials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Financials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Financials",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Financials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Financials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Fees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Fees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Fees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Fees",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Fees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ethnicities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Ethnicities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Ethnicities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Ethnicities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ethnicities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Ethnicities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Ethnicities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Ethnicities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Ethnicities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Emergencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Emergencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Emergencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Emergencies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Emergencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Emergencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Emergencies",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Emergencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Emergencies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Disabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Disabilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Disabilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Disabilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Disabilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Disabilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Disabilities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Disabilities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Disabilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Citizenships",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Citizenships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Citizenships",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Citizenships",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Citizenships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Citizenships",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Citizenships",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Citizenships",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Citizenships",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Banks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Banks",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Awards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Awards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Awards",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Awards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Awards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Awards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Awards",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Awards",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Awards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Addresses",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AcademicHistorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AcademicHistorys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AcademicHistorys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "AcademicHistorys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AcademicHistorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "AcademicHistorys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AcademicHistorys",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AcademicHistorys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AcademicHistorys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AcademicEnrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AcademicEnrollments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AcademicEnrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "AcademicEnrollments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AcademicEnrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "AcademicEnrollments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AcademicEnrollments",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AcademicEnrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "AcademicEnrollments",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SecondaryInfos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OtherInformations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Financials");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Ethnicities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Emergencies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Disabilities");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Citizenships");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Awards");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AcademicHistorys");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AcademicEnrollments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AcademicEnrollments");
        }
    }
}
