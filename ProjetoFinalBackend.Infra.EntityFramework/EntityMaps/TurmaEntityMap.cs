using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class TurmaEntityMap : IEntityTypeConfiguration<Turma>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable(nameof(Turma));
        builder.HasKey(t => new {t.CursoId, t.TurmaId } );
        builder.Property(t => t.TurmaId);
        builder.Property(t => t.Nome).HasMaxLength(20);
        builder.Property(t => t.Numero);
        builder.Property(t => t.Tamanho);
        builder.Ignore(t => t.QtdAlunos);
        builder.HasOne(t => t.Curso)
            .WithMany(c => c.Turmas)
            .HasForeignKey(c => c.CursoId);
        builder.HasMany(t => t.Atividades)
            .WithOne(a => a.Turma)
            .HasForeignKey(a => new {a.CursoId, a.TurmaId });
        builder.HasMany(t => t.Alunos).WithOne(a => a.Turma);
        builder.HasMany(t => t.Forums)
            .WithOne(f => f.Turma)
            .HasForeignKey(f => new{f.CursoId, f.TurmaId});
    }
}