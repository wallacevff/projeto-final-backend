using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.ConteudoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class AtividadeEntityMap : IEntityTypeConfiguration<Atividade>
{
    public void Configure(EntityTypeBuilder<Atividade> builder)
    {

    }
}