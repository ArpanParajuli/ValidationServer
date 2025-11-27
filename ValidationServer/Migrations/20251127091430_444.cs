using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationServer.Migrations
{
    /// <inheritdoc />
    public partial class _444 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Father");

            migrationBuilder.DropTable(
                name: "Mother");

            migrationBuilder.DropTable(
                name: "PermanentAddresses");

            migrationBuilder.DropTable(
                name: "TemporaryAddresses");

            migrationBuilder.DropColumn(
                name: "GuardianEmail",
                table: "Guardians");

            migrationBuilder.RenameColumn(
                name: "ScholarshipType",
                table: "Scholarships",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ScholarshipProviderName",
                table: "Scholarships",
                newName: "ProviderName");

            migrationBuilder.RenameColumn(
                name: "ScholarshipAmount",
                table: "Scholarships",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "GuardianRelation",
                table: "Guardians",
                newName: "Occupation");

            migrationBuilder.RenameColumn(
                name: "GuardianOccupation",
                table: "Guardians",
                newName: "MobileNumber");

            migrationBuilder.RenameColumn(
                name: "GuardianMobileNumber",
                table: "Guardians",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "GuardianFullName",
                table: "Guardians",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Relation",
                table: "Guardians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToleStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "Guardians");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Scholarships",
                newName: "ScholarshipType");

            migrationBuilder.RenameColumn(
                name: "ProviderName",
                table: "Scholarships",
                newName: "ScholarshipProviderName");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Scholarships",
                newName: "ScholarshipAmount");

            migrationBuilder.RenameColumn(
                name: "Occupation",
                table: "Guardians",
                newName: "GuardianRelation");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "Guardians",
                newName: "GuardianOccupation");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Guardians",
                newName: "GuardianMobileNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Guardians",
                newName: "GuardianFullName");

            migrationBuilder.AddColumn<string>(
                name: "GuardianEmail",
                table: "Guardians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Father",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FatherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Father", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Father_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mother",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MotherDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mother", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mother_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermanentAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PermanentDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentHouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentToleStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentWardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isTemporarySame = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermanentAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermanentAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemporaryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TemporaryDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryHouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryToleStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryWardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporaryAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Father_StudentId",
                table: "Father",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mother_StudentId",
                table: "Mother",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PermanentAddresses_StudentId",
                table: "PermanentAddresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryAddresses_StudentId",
                table: "TemporaryAddresses",
                column: "StudentId");
        }
    }
}
