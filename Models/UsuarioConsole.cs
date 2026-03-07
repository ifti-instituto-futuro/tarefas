using tarefas.Enums;

namespace tarefas.Models;
    
public class UsuarioConsole
{
    public UsuarioConsole(string idUsuario, string nome, PerfilAcessoEnum perfilAcesso, CargoEnum? cargo, List<PermissaoSistema> permissoes)
    {
        IdUsuario = idUsuario;
        Nome = nome;
        PerfilAcesso = perfilAcesso;
        Cargo = cargo;
        Permissoes = permissoes;
    }

    public string IdUsuario { get; }
    public string Nome { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public CargoEnum? Cargo { get; }

    public List<PermissaoSistema> Permissoes { get; }

    public bool PossuiPermissao(OpcaoMenuEnum opcao, TipoPermissaoEnum tipoPermissao)
        => Permissoes.Any(p => p.OpcaoMenu == opcao && p.TipoPermissao == tipoPermissao);

    public IEnumerable<OpcaoMenuEnum> ObterOpcoesDisponiveis()
    {
        var teste = Permissoes.Select(p => p.OpcaoMenu).Distinct().OrderBy(p => p.ToString());
        return teste; // TODO: removcer apos testar
    }
}
