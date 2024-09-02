using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class ArquivoEntityMap : IEntityTypeConfiguration<Arquivo>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Arquivo> builder)
    {
        builder.HasDiscriminator(a => a.TipoArquivo)
            .HasValue<Documento>(TipoArquivo.Documento)
            .HasValue<Video>(TipoArquivo.Video)
            .HasValue<Imagem>(TipoArquivo.Imagem)
            ;
    }
}