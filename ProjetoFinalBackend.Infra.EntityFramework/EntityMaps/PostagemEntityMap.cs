using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class PostagemEntityMap : IEntityTypeConfiguration<Postagem>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Postagem> builder)
    {
        builder.ToTable(nameof(Postagem));
        builder.HasKey(p => new { p.CursoId, p.TurmaId, p.ForumId, p.PostagemId });
        builder.Property(p => p.CursoId);
        builder.Property(p => p.TurmaId);
        builder.Property(p => p.ForumId);
        builder.Property(p => p.PostagemId);
        builder.Property(p => p.PostagemPrincipalCursoId);
        builder.Property(p => p.PostagemPrincipalTurmaId);
        builder.Property(p => p.PostagemPrincipalForumId);
        builder.Property(p => p.PostagemPrincipalPostagemId);
        builder.Property(p => p.Titulo);
        builder.Property(p => p.Conteudo);
        builder.Property(p => p.DataCriacao);
        builder.Property(p => p.DeletedAt);
        builder.Property(p => p.UpdatedAt);
        builder.Property(p => p.CreatedAt);

        builder.HasOne(p => p.Forum).WithMany(f => f.Postagens)
            .HasForeignKey(p => new { p.CursoId, p.TurmaId, p.ForumId });

        builder.HasOne(p => p.PostagemPrincipal).WithMany(p => p.Respostas)
            .HasForeignKey(p => new { p.PostagemPrincipalCursoId, p.PostagemPrincipalTurmaId, p.PostagemPrincipalForumId, p.PostagemPrincipalPostagemId });
    }
}