using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinary_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Veterinaries",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Veterinaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Veterinaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Veterinaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Veterinaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearStartedWorking",
                table: "Veterinaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientVeterinary",
                columns: table => new
                {
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    VeterinariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVeterinary", x => new { x.PatientsId, x.VeterinariesId });
                    table.ForeignKey(
                        name: "FK_PatientVeterinary_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVeterinary_Veterinaries_VeterinariesId",
                        column: x => x.VeterinariesId,
                        principalTable: "Veterinaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veterinaries_ClinicId",
                table: "Veterinaries",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_PatientId",
                table: "MedicalRecord",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_SpecieId",
                table: "Patient",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVeterinary_VeterinariesId",
                table: "PatientVeterinary",
                column: "VeterinariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinaries_Clinic_ClinicId",
                table: "Veterinaries",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veterinaries_Clinic_ClinicId",
                table: "Veterinaries");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "PatientVeterinary");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Veterinaries_ClinicId",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Veterinaries");

            migrationBuilder.DropColumn(
                name: "YearStartedWorking",
                table: "Veterinaries");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Veterinaries",
                newName: "Nombre");
        }
    }
}
