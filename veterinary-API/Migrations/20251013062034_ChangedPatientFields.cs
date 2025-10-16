﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinary_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPatientFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");
        }
    }
}
