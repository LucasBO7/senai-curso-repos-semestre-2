using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.event_.tarde.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyInserida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Instituicao_InstituicaoIdInstituicao",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_InstituicaoIdInstituicao",
                table: "Evento");

            migrationBuilder.DropColumn(
                name: "InstituicaoIdInstituicao",
                table: "Evento");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdInstituicao",
                table: "Evento",
                column: "IdInstituicao");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Instituicao_IdInstituicao",
                table: "Evento",
                column: "IdInstituicao",
                principalTable: "Instituicao",
                principalColumn: "IdInstituicao",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Instituicao_IdInstituicao",
                table: "Evento");

            migrationBuilder.DropIndex(
                name: "IX_Evento_IdInstituicao",
                table: "Evento");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituicaoIdInstituicao",
                table: "Evento",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evento_InstituicaoIdInstituicao",
                table: "Evento",
                column: "InstituicaoIdInstituicao");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Instituicao_InstituicaoIdInstituicao",
                table: "Evento",
                column: "InstituicaoIdInstituicao",
                principalTable: "Instituicao",
                principalColumn: "IdInstituicao");
        }
    }
}
