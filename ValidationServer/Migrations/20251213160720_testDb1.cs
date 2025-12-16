using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationServer.Migrations
{
    /// <inheritdoc />
    public partial class testDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AcademicStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BoardUniversity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassedYear = table.Column<DateOnly>(type: "date", nullable: false),
                    DivisionOrGPA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicHistorys_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citizenships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenshipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenshipIssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CitizenshipIssueDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citizenships_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisabilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabilityPercentage = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disabilities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emergencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emergencies_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EthnicityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EthnicityGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ethnicities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Financials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualFamilyIncome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financials_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nationalities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scholarships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScholarshipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScholarshipProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScholarshipAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scholarships_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryInfos_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicEnrollments_StudentId",
                table: "AcademicEnrollments",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicHistorys_StudentId",
                table: "AcademicHistorys",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_StudentId",
                table: "Banks",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizenships_StudentId",
                table: "Citizenships",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disabilities_StudentId",
                table: "Disabilities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StudentId",
                table: "Documents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_StudentId",
                table: "Emergencies",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ethnicities_StudentId",
                table: "Ethnicities",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StudentId",
                table: "Fees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Financials_StudentId",
                table: "Financials",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardians",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_StudentId",
                table: "Nationalities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_StudentId",
                table: "Scholarships",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryInfos_StudentId",
                table: "SecondaryInfos",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicEnrollments");

            migrationBuilder.DropTable(
                name: "AcademicHistorys");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Citizenships");

            migrationBuilder.DropTable(
                name: "Disabilities");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Emergencies");

            migrationBuilder.DropTable(
                name: "Ethnicities");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Financials");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Scholarships");

            migrationBuilder.DropTable(
                name: "SecondaryInfos");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
