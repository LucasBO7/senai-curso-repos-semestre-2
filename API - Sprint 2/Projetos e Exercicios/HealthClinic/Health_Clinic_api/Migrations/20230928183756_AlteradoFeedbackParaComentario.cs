using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health_Clinic_api.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoFeedbackParaComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Comentario_IdFeedback",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "IdFeedback",
                table: "Consulta",
                newName: "IdComentario");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_IdFeedback",
                table: "Consulta",
                newName: "IX_Consulta_IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta",
                column: "IdComentario",
                principalTable: "Comentario",
                principalColumn: "IdComentario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Comentario_IdComentario",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "IdComentario",
                table: "Consulta",
                newName: "IdFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_IdComentario",
                table: "Consulta",
                newName: "IX_Consulta_IdFeedback");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Comentario_IdFeedback",
                table: "Consulta",
                column: "IdFeedback",
                principalTable: "Comentario",
                principalColumn: "IdComentario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
