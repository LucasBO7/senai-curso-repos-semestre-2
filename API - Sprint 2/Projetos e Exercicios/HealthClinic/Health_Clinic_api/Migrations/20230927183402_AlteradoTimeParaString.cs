using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic_api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoTimeParaString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "VARCHAR(5)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");

            migrationBuilder.AlterColumn<string>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "VARCHAR(5)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)");
        }
    }
}
