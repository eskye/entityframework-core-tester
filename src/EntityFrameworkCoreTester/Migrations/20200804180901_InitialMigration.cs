using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreTester.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(150)", nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CreatorUserKey = table.Column<Guid>(nullable: false),
                    ModifierUserKey = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatorUserKey = table.Column<Guid>(nullable: false),
                    ModifierUserKey = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefApplicationOutcomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutComeCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", nullable: true),
                    Key = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefApplicationOutcomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", nullable: true),
                    Key = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefApplicationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefComplaintOutcomes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutComeCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", nullable: true),
                    Key = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefComplaintOutcomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefComplaintStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    Description = table.Column<string>(type: "varchar(150)", nullable: true),
                    Key = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefComplaintStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramApplications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<long>(nullable: false),
                    ProgramId = table.Column<long>(nullable: false),
                    RefApplicationOutComeId = table.Column<long>(nullable: false),
                    RefApplicationStatusId = table.Column<long>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Key = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramApplications_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramApplications_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramApplications_RefApplicationOutcomes_RefApplicationOutComeId",
                        column: x => x.RefApplicationOutComeId,
                        principalTable: "RefApplicationOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramApplications_RefApplicationStatuses_RefApplicationStatusId",
                        column: x => x.RefApplicationStatusId,
                        principalTable: "RefApplicationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentComplaints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<Guid>(nullable: false),
                    IsResponded = table.Column<bool>(nullable: false),
                    DateOfComplaint = table.Column<DateTime>(nullable: false),
                    ComplaintText = table.Column<string>(type: "varchar(256)", nullable: true),
                    ResponseText = table.Column<string>(type: "varchar(256)", nullable: true),
                    ProgramApplicationId = table.Column<long>(nullable: false),
                    RefComplaintOutComeId = table.Column<long>(nullable: false),
                    RefComplaintStatusId = table.Column<long>(nullable: false),
                    CreatorUserKey = table.Column<Guid>(nullable: false),
                    ModifierUserKey = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentComplaints_ProgramApplications_ProgramApplicationId",
                        column: x => x.ProgramApplicationId,
                        principalTable: "ProgramApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentComplaints_RefComplaintOutcomes_RefComplaintOutComeId",
                        column: x => x.RefComplaintOutComeId,
                        principalTable: "RefComplaintOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentComplaints_RefComplaintStatuses_RefComplaintStatusId",
                        column: x => x.RefComplaintStatusId,
                        principalTable: "RefComplaintStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramApplications_ApplicantId",
                table: "ProgramApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramApplications_ProgramId",
                table: "ProgramApplications",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramApplications_RefApplicationOutComeId",
                table: "ProgramApplications",
                column: "RefApplicationOutComeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramApplications_RefApplicationStatusId",
                table: "ProgramApplications",
                column: "RefApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentComplaints_ProgramApplicationId",
                table: "StudentComplaints",
                column: "ProgramApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentComplaints_RefComplaintOutComeId",
                table: "StudentComplaints",
                column: "RefComplaintOutComeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentComplaints_RefComplaintStatusId",
                table: "StudentComplaints",
                column: "RefComplaintStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentComplaints");

            migrationBuilder.DropTable(
                name: "ProgramApplications");

            migrationBuilder.DropTable(
                name: "RefComplaintOutcomes");

            migrationBuilder.DropTable(
                name: "RefComplaintStatuses");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "RefApplicationOutcomes");

            migrationBuilder.DropTable(
                name: "RefApplicationStatuses");
        }
    }
}
