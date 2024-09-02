using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.ForumModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class ForumEntityMap : IEntityTypeConfiguration<Forum>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Forum> builder)
    {
        builder.ToTable(nameof(Forum));
        builder.HasKey(f => new {f.CursoId, f.TurmaId, f.ForumId});
        builder.Property(aa => aa.CursoId);
        builder.Property(aa => aa.TurmaId);
        builder.Property(aa => aa.ForumId);
        builder.Property(f => f.Titulo);
        builder.Property(f => f.CreatedAt);
        builder.HasMany(f => f.Postagens).WithOne(p => p.Forum)
            .HasForeignKey(p => new { p.CursoId, p.TurmaId, p.ForumId });
    }
}