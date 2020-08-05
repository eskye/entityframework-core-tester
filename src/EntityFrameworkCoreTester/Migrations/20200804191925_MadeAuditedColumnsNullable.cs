using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreTester.Migrations
{
    public partial class MadeAuditedColumnsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "StudentComplaints",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "StudentComplaints",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "Programs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "Programs",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "ProgramApplications",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "Applicants",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "Applicants",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "StudentComplaints",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "StudentComplaints",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "Programs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "Programs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "ProgramApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifierUserKey",
                table: "Applicants",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationTime",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
