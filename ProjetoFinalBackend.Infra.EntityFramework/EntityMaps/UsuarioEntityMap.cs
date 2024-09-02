using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.SistemaModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class UsuarioEntityMap : IEntityTypeConfiguration<Usuario>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));
        builder.HasKey(u => u.Id);
        Properties(builder);
        builder.HasDiscriminator(u => u.TipoUsuarioId)
            .HasValue<Professor>(TipoUsuarioEnum.Professor)
            .HasValue<Aluno>(TipoUsuarioEnum.Aluno);
        builder.HasOne(u => u.TipoUsuario)
            .WithMany()
            .HasForeignKey(u => u.TipoUsuarioId);
        builder.HasOne(u => u.Imagem).WithOne();

    }

    #region Properties
    private EntityTypeBuilder<Usuario> Properties(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(u => u.Id);
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.ImagemId);
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
        builder.Property(u => u.DeletedAt);

        return builder;
    }

    #endregion

}