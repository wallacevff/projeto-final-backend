using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class UsuarioEntityMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));
        builder.HasKey(u => u.Id);
        Properties(builder);
        builder.HasDiscriminator(u => u.TipoUsuario)
            .HasValue<Professor>(new TipoUsuario {Id = 1, Nome = "Professor"})
            .HasValue<Aluno>(new TipoUsuario { Id = 2, Nome = "Aluno" });
        builder.HasOne(u => u.TipoUsuario)
            .WithMany()
            .HasForeignKey(u => u.TipoUsuarioId);
   
    }

    #region Properties
    private EntityTypeBuilder<Usuario> Properties(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(u => u.Id);
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.TipoUsuario);
        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
        builder.Property(u => u.DeletedAt);

        return builder;
    }

    #endregion

}