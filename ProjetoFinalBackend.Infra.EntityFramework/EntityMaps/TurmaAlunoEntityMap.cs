using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class TurmaAlunoEntityMap : IEntityTypeConfiguration<TurmaAluno>, IEntityMap
{
    public void Configure(EntityTypeBuilder<TurmaAluno> builder)
    {
        builder.ToTable(nameof(TurmaAluno));
        builder.HasKey(t => new {t.CursoId, t.TurmaId, t.AlunoId});
        builder.Property(t => t.TurmaId);
        builder.Property(t => t.AlunoId);
        builder.Property(t => t.CursoId);
        builder.HasOne(t => t.Curso).WithMany().HasForeignKey(t => t.CursoId);
        builder.HasOne(t => t.Aluno)
            .WithMany(a => a.Turmas)
            .HasForeignKey(a => a.AlunoId);
        builder.HasOne(t => t.Turma)
            .WithMany().HasForeignKey(t => new {t.CursoId, t.TurmaId});
    }
}