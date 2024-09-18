using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalBackend.Infra.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavbarItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavbarItemTipoUsuario",
                columns: table => new
                {
                    NavbarId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarItemTipoUsuario", x => new { x.NavbarId, x.TipoUsuarioId });
                    table.ForeignKey(
                        name: "FK_NavbarItemTipoUsuario_NavbarItem_NavbarId",
                        column: x => x.NavbarId,
                        principalTable: "NavbarItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavbarItemTipoUsuario_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArquivoAtividade",
                columns: table => new
                {
                    AnexosId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AtividadeCursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AtividadeTurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AtividadeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoAtividade", x => new { x.AnexosId, x.AtividadeCursoId, x.AtividadeTurmaId, x.AtividadeId });
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RepositorioArquivoId = table.Column<string>(type: "TEXT", nullable: true),
                    Extensao = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    TipoArquivo = table.Column<int>(type: "INTEGER", nullable: false),
                    PostagemCursoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemForumId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemTurmaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    ImagemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TipoUsuarioCod = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Arquivos_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Arquivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioCod",
                        column: x => x.TipoUsuarioCod,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    ProfessorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Modalidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Numero = table.Column<short>(type: "INTEGER", nullable: false),
                    Tamanho = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => new { x.CursoId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_Turma_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    AtividadeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    TipoAtividade = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Avaliacao = table.Column<bool>(type: "INTEGER", nullable: true),
                    PrazoDeEntrega = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => new { x.CursoId, x.TurmaId, x.AtividadeId });
                    table.ForeignKey(
                        name: "FK_Atividade_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atividade_Turma_CursoId_TurmaId",
                        columns: x => new { x.CursoId, x.TurmaId },
                        principalTable: "Turma",
                        principalColumns: new[] { "CursoId", "TurmaId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ForumId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => new { x.CursoId, x.TurmaId, x.ForumId });
                    table.ForeignKey(
                        name: "FK_Forum_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forum_Turma_CursoId_TurmaId",
                        columns: x => new { x.CursoId, x.TurmaId },
                        principalTable: "Turma",
                        principalColumns: new[] { "CursoId", "TurmaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forum_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaAluno",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaAluno", x => new { x.CursoId, x.TurmaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Turma_CursoId_TurmaId",
                        columns: x => new { x.CursoId, x.TurmaId },
                        principalTable: "Turma",
                        principalColumns: new[] { "CursoId", "TurmaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaAluno_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeAluno",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AtividadeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Concluida = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeAluno", x => new { x.CursoId, x.TurmaId, x.AtividadeId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_AtividadeAluno_Atividade_CursoId_TurmaId_AtividadeId",
                        columns: x => new { x.CursoId, x.TurmaId, x.AtividadeId },
                        principalTable: "Atividade",
                        principalColumns: new[] { "CursoId", "TurmaId", "AtividadeId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeAluno_Usuario_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postagem",
                columns: table => new
                {
                    PostagemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TurmaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ForumId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PostagemPrincipalCursoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemPrincipalTurmaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemPrincipalForumId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostagemPrincipalPostagemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Conteudo = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagem", x => new { x.CursoId, x.TurmaId, x.ForumId, x.PostagemId });
                    table.ForeignKey(
                        name: "FK_Postagem_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postagem_Forum_CursoId_TurmaId_ForumId",
                        columns: x => new { x.CursoId, x.TurmaId, x.ForumId },
                        principalTable: "Forum",
                        principalColumns: new[] { "CursoId", "TurmaId", "ForumId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postagem_Postagem_PostagemPrincipalCursoId_PostagemPrincipalTurmaId_PostagemPrincipalForumId_PostagemPrincipalPostagemId",
                        columns: x => new { x.PostagemPrincipalCursoId, x.PostagemPrincipalTurmaId, x.PostagemPrincipalForumId, x.PostagemPrincipalPostagemId },
                        principalTable: "Postagem",
                        principalColumns: new[] { "CursoId", "TurmaId", "ForumId", "PostagemId" });
                    table.ForeignKey(
                        name: "FK_Postagem_Turma_CursoId_TurmaId",
                        columns: x => new { x.CursoId, x.TurmaId },
                        principalTable: "Turma",
                        principalColumns: new[] { "CursoId", "TurmaId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postagem_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoAtividade_AtividadeCursoId_AtividadeTurmaId_AtividadeId",
                table: "ArquivoAtividade",
                columns: new[] { "AtividadeCursoId", "AtividadeTurmaId", "AtividadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_PostagemCursoId_PostagemTurmaId_PostagemForumId_PostagemId",
                table: "Arquivos",
                columns: new[] { "PostagemCursoId", "PostagemTurmaId", "PostagemForumId", "PostagemId" });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeAluno_AlunoId",
                table: "AtividadeAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_ProfessorId",
                table: "Curso",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_UsuarioId",
                table: "Forum",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarItemTipoUsuario_TipoUsuarioId",
                table: "NavbarItemTipoUsuario",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_PostagemPrincipalCursoId_PostagemPrincipalTurmaId_PostagemPrincipalForumId_PostagemPrincipalPostagemId",
                table: "Postagem",
                columns: new[] { "PostagemPrincipalCursoId", "PostagemPrincipalTurmaId", "PostagemPrincipalForumId", "PostagemPrincipalPostagemId" });

            migrationBuilder.CreateIndex(
                name: "IX_Postagem_UsuarioId",
                table: "Postagem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaAluno_AlunoId",
                table: "TurmaAluno",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ImagemId",
                table: "Usuario",
                column: "ImagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioCod",
                table: "Usuario",
                column: "TipoUsuarioCod");

            migrationBuilder.AddForeignKey(
                name: "FK_ArquivoAtividade_Arquivos_AnexosId",
                table: "ArquivoAtividade",
                column: "AnexosId",
                principalTable: "Arquivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArquivoAtividade_Atividade_AtividadeCursoId_AtividadeTurmaId_AtividadeId",
                table: "ArquivoAtividade",
                columns: new[] { "AtividadeCursoId", "AtividadeTurmaId", "AtividadeId" },
                principalTable: "Atividade",
                principalColumns: new[] { "CursoId", "TurmaId", "AtividadeId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Postagem_PostagemCursoId_PostagemTurmaId_PostagemForumId_PostagemId",
                table: "Arquivos",
                columns: new[] { "PostagemCursoId", "PostagemTurmaId", "PostagemForumId", "PostagemId" },
                principalTable: "Postagem",
                principalColumns: new[] { "CursoId", "TurmaId", "ForumId", "PostagemId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Arquivos_ImagemId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "ArquivoAtividade");

            migrationBuilder.DropTable(
                name: "AtividadeAluno");

            migrationBuilder.DropTable(
                name: "NavbarItemTipoUsuario");

            migrationBuilder.DropTable(
                name: "TurmaAluno");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "NavbarItem");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Postagem");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
