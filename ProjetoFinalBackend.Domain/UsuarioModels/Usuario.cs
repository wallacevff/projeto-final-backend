﻿using ProjetoFinalBackend.Domain.SistemaModels.ArquivoModels;

namespace ProjetoFinalBackend.Domain.UsuarioModels;

public abstract class Usuario : DefaultEntity<Guid>
{

    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid ImagemId { get; set; }
    public Arquivo? Imagem { get; set; }
    public Guid TipoUsuarioId { get; set; }
    public TipoUsuario? TipoUsuario { get; set; }
}