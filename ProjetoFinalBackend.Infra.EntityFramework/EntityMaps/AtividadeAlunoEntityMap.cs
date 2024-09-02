using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.ConteudoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class AtividadeAlunoEntityMap : IEntityTypeConfiguration<AtividadeAluno>, IEntityMap
{
    public void Configure(EntityTypeBuilder<AtividadeAluno> builder)
    {
        builder.ToTable(nameof(AtividadeAluno));
        builder.HasKey(aa => new { aa.TurmaId, aa.AtividadeId, aa.AlunoId });
        builder.Property(aa => aa.AlunoId);
        builder.Property(aa => aa.AtividadeId);
        builder.Property(aa => aa.TurmaId);
        builder.HasOne(aa => aa.Aluno).WithMany().HasForeignKey(aa => aa.AlunoId);
        builder.HasOne(aa => aa.Atividade).WithMany().HasForeignKey(aa => new {aa.TurmaId, aa.AtividadeId});
    }
}