using tarefas.Enums;

namespace tarefas.Models;

public class PermissaoSistema(PerfilAcessoEnum perfil, OpcaoMenuEnum opcao, TipoPermissaoEnum tipoPermissao)
{
    public PerfilAcessoEnum PerfilAcesso { get; } = perfil;
    public OpcaoMenuEnum OpcaoMenu { get; } = opcao;
    public TipoPermissaoEnum TipoPermissao { get; } = tipoPermissao;
}
