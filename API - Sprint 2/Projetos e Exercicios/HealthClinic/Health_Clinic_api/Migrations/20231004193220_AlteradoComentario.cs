using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic_api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdComentario",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdComentario",
                table: "Consulta");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Paciente",
                type: "VARCHAR(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7)");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConsulta",
                table: "Comentario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_IdConsulta",
                table: "Comentario",
                column: "IdConsulta",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Consulta_IdConsulta",
                table: "Comentario",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "IdConsulta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Consulta_IdConsulta",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_IdConsulta",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Comentario");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Paciente",
                type: "VARCHAR(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(9)");

            migrationBuilder.AddColumn<Guid>(
                name: "IdComentario",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdComentario",
                table: "Consulta",
                column: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta",
                column: "IdComentario",
                principalTable: "Comentario",
                principalColumn: "IdComentario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
