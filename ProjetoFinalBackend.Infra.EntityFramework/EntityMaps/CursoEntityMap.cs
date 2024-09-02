using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.CursoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class CursoEntityMap : IEntityTypeConfiguration<Curso>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable(nameof(Curso));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ProfessorId).IsRequired();
        builder.Property(x => x.Modalidade);
        builder.Property(x => x.Descricao).HasMaxLength(1024);
        builder.HasMany(x => x.Turmas)
            .WithOne(t => t.Curso)
            .HasForeignKey(t => t.CursoId);
        builder.HasOne(c => c.Professor)
            .WithMany(p => p.Cursos)
            .HasForeignKey(c => c.ProfessorId);
    }
}