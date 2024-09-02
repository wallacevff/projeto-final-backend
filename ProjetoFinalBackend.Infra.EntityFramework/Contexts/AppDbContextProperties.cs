using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.Contexts;

public partial class AppDbContext
{
    public DbSet<TipoUsuario> TiposUsuario { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<AtividadeAluno> AtividadesAluno { get; set; }
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Forum> Forums { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<TurmaAluno> TurmasAlunos { get; set; }
    public DbSet<Imagem> Imagens { get; set; }
    public DbSet<Video> Videos { get; set; }
    //public DbSet<Usuario> Usuarios { get; set; }
    //public DbSet<Usuario> Usuarios { get; set; }
    //public DbSet<Usuario> Usuarios { get; set; }
}