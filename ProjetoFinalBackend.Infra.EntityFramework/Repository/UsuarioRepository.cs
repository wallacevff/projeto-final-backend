using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.Shared.Filters;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class UsuarioRepository : DefaultRepository<Usuario, UsuarioFilter, Guid>
{
    public UsuarioRepository(AppDbContext context) : base(context) { }

    public async Task<Usuario> Login(string usuario, string senha)
    {
        return await DbSet
            .Include(u => u.TipoUsuario)
            .ThenInclude(tu => tu!.Navbar)
            .FirstAsync(
            u => u.Email == usuario && u.Senha == senha);
    }

}