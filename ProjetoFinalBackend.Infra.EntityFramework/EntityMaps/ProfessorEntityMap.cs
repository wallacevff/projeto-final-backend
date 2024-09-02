using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalBackend.Domain.CursoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.EntityMaps;

public class ProfessorEntityMap : IEntityTypeConfiguration<Professor>, IEntityMap
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasMany(c => c.Cursos)
            .WithOne(c => c.Professor)
            .HasForeignKey(c => c.ProfessorId)
            ;
    }
}