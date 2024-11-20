using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalBackend.Infra.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioOtherKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email_Senha",
                table: "Usuario",
                columns: new[] { "Email", "Senha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Email_Senha",
                table: "Usuario");
        }
    }
}
