using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.ConteudoModels;
using ProjetoFinalBackend.Domain.ForumModels;
using ProjetoFinalBackend.Domain.UsuarioModels;

namespace ProjetoFinalBackend.Infra.EntityFramework.Contexts;

public partial class AppDbContext : DbContext
{
    

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(IProjetoFinalInfraEntityFramework).Assembly,
            type => type.GetInterfaces().Any(t => t == typeof(IEntityMap))
        );
        
        //
    }
}