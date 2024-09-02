using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class TipoUsuarioEntityMap : IEntityTypeConfiguration<TipoUsuario>, IEntityMap
{
    public void Configure(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.ToTable(nameof(TipoUsuario));
        builder.HasKey(u => u.Id);
        Properties(builder);
        builder.HasMany(tu => tu.Navbar).WithMany();
    }

    private EntityTypeBuilder<TipoUsuario> Properties(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.Property(u => u.Id);
        builder.Property(u => u.Nome);
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
        builder.Property(u => u.DeletedAt);
        return builder;
    }
}