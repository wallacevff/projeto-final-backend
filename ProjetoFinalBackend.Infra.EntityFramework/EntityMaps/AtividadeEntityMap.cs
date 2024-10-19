using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class AtividadeEntityMap : IEntityTypeConfiguration<Atividade>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Atividade> builder)
    {
        builder.ToTable(nameof(Atividade));
        builder.HasKey(a => new {a.CursoId,  a.TurmaId, a.AtividadeId });
        builder.Property(a => a.TurmaId).IsRequired();
        builder.Property(a => a.AtividadeId).IsRequired();
        builder.Property(a => a.CreatedAt);
        builder.Property(a => a.DataCriacao);
        builder.Property(a => a.UpdatedAt);
        builder.Property(a => a.DeletedAt);
        builder.HasOne(a => a.Turma)
            .WithMany(t => t.Atividades)
            .HasForeignKey(a => new {a.CursoId, a.TurmaId});
        builder.HasMany(a => a.Anexos).WithMany();
        builder.HasDiscriminator(a => a.TipoAtividade)
            .HasValue<Tarefa>(TipoAtividade.Tarefa)
            .HasValue<Materia>(TipoAtividade.Materia);

    }
}