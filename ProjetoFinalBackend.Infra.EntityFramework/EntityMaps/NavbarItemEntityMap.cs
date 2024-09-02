using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class NavbarItemEntityMap : IEntityTypeConfiguration<NavbarItem>, IEntityMap
{
    public void Configure(EntityTypeBuilder<NavbarItem> builder)
    {
        builder.ToTable(nameof(NavbarItem));
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id);
        builder.Property(n => n.Nome)
            .HasColumnName("Titulo")
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(o => o.Url);
        builder.Property(o => o.CreatedAt);
        builder.Property(o => o.UpdatedAt);
        builder.Property(o => o.DeletedAt);

    }
}