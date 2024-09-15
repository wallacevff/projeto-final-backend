using Microsoft.EntityFrameworkCore;
using ProjetoFinalBackend.Domain.UsuarioModels;
using ProjetoFinalBackend.Infra.EntityFramework.Contexts;

namespace ProjetoFinalBackend.Infra.EntityFramework.Repository;

public class UsuarioRepository : DefaultRepository<Usuario>
{
    public UsuarioRepository(AppDbContext context) : base(context) { }

    public async Task<Usuario> Login(string usuario, string senha)
    {
        return await _dbSet
            .Include(u => u.TipoUsuario)
            .ThenInclude(tu => tu!.Navbar)
            .FirstAsync(
            u => u.Email == usuario && u.Senha == senha);
    }

    public async Task<Usuario?> CreateUser(Usuario usuario)
    {
        return await base.AddAsync(usuario);
    }
}