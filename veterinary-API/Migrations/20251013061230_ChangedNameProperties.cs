using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinary_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Patient_PatientId",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Species_SpecieId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVeterinary_Patient_PatientsId",
                table: "PatientVeterinary");

            migrationBuilder.DropForeignKey(
                name: "FK_Veterinaries_Clinic_ClinicId",
                table: "Veterinaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecord",
                table: "MedicalRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "MedicalRecord",
                newName: "MedicalRecords");

            migrationBuilder.RenameTable(
                name: "Clinic",
                newName: "Clinics");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_SpecieId",
                table: "Patients",
                newName: "IX_Patients_SpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecord_PatientId",
                table: "MedicalRecords",
                newName: "IX_MedicalRecords_PatientId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Species_SpecieId",
                table: "Patients",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVeterinary_Patients_PatientsId",
                table: "PatientVeterinary",
                column: "PatientsId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinaries_Clinics_ClinicId",
                table: "Veterinaries",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Species_SpecieId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientVeterinary_Patients_PatientsId",
                table: "PatientVeterinary");

            migrationBuilder.DropForeignKey(
                name: "FK_Veterinaries_Clinics_ClinicId",
                table: "Veterinaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "MedicalRecords",
                newName: "MedicalRecord");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "Clinic");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_SpecieId",
                table: "Patient",
                newName: "IX_Patient_SpecieId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecord",
                newName: "IX_MedicalRecord_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecord",
                table: "MedicalRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinic",
                table: "Clinic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Patient_PatientId",
                table: "MedicalRecord",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Species_SpecieId",
                table: "Patient",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientVeterinary_Patient_PatientsId",
                table: "PatientVeterinary",
                column: "PatientsId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinaries_Clinic_ClinicId",
                table: "Veterinaries",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
