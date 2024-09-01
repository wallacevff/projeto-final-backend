using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class TipoUsuarioEntityMap : IEntityTypeConfiguration<TipoUsuario>
{
    public void Configure(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.ToTable(nameof(TipoUsuario));
        builder.HasKey(u => u.Id);
        Properties(builder);
        builder.OwnsMany(tu => tu.Navbar,
                n =>
                {
                    n.ToTable(nameof(NavbarItem));
                    n.HasKey(n => n.Id);
                    n.Property(n => n.Id);
                    n.Property(n => n.Nome).HasColumnName("Titulo");
                    n.Property(n => n.Url);
                })
            
            ;

    }

    private EntityTypeBuilder<TipoUsuario> Properties(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.Property(u => u.Id);
        builder.Property(u => u.Nome);
        builder.Property(u => u.Navbar);
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
        builder.Property(u => u.DeletedAt);
        return builder;
    }
}