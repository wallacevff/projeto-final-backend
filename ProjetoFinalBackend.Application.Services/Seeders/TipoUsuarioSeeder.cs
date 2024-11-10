using ProjetoFinalBackend.Application.Contracts.Dtos.Usuario;
using ProjetoFinalBackend.Application.Contracts.Services;
using ProjetoFinalBackend.Domain.Shared.Enums;

namespace ProjetoFinalBackend.Application.Services.Seeders;

public class TipoUsuarioSeeder(ITipoUsuarioService tipoUsuarioService)
{

    public async Task Seed()
    {
        var tipoUsuariosCadastrados = await tipoUsuarioService.HasAnyAsync();
        if (tipoUsuariosCadastrados)
            return;

        var tiposUsuarios = GetTipoUsuariosForInsert();
        await tipoUsuarioService.AddRangeAsync(tiposUsuarios);
    }


    private IList<TipoUsuarioCadastroDto> GetTipoUsuariosForInsert()
    {
        IList<TipoUsuarioCadastroDto> tipoUsuarios =
        [
            new()
            {
                Id = TipoUsuarioEnum.Professor,
                Nome = "Professor",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Navbar =
                [
                    new()
                    {
                        Nome = "Home",
                        Url = "/",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new()
                    {
                        Nome = "Cursos",
                        Url = "/curso",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new()
                    {
                        Nome = "Criar Curso",
                        Url = "/curso/criar",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                ]
            },
            new()
            {
                Id = TipoUsuarioEnum.Aluno,
                Nome = "Aluno",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Navbar =
                [
                    new()
                    {
                        Nome = "Home",
                        Url = "/",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new()
                    {
                        Nome = "Meus Cursos",
                        Url = "/curso",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new()
                    {
                        Nome = "Minhas Notas",
                        Url = "/notas",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new()
                    {
                        Nome = "Inscrição Cursos",
                        Url = "/curso?all=true",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                ]
            }

        ];

        return tipoUsuarios;
    }

}