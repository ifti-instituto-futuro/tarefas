using tarefas.Enums;
using tarefas.Models;

namespace tarefas.Mock;
    
public class PermissaoFactory
{
    public static List<PermissaoSistema> CriarPermissoesMock()
    {
        return new List<PermissaoSistema>
        {
            //funcionario
            new PermissaoSistema(PerfilAcessoEnum.Funcionario, OpcaoMenuEnum.ListarTarefas, TipoPermissaoEnum.Visualizar),

            //gerente 
            new PermissaoSistema(PerfilAcessoEnum.Gerente, OpcaoMenuEnum.ListarTarefas, TipoPermissaoEnum.Visualizar),
            new PermissaoSistema(PerfilAcessoEnum.Gerente, OpcaoMenuEnum.ListarUsuarios, TipoPermissaoEnum.Visualizar),
            new PermissaoSistema(PerfilAcessoEnum.Gerente, OpcaoMenuEnum.CadastrarTarefa, TipoPermissaoEnum.Criar),
            new PermissaoSistema(PerfilAcessoEnum.Gerente, OpcaoMenuEnum.AtribuirTarefa, TipoPermissaoEnum.Criar),

            //administrador
            new PermissaoSistema(PerfilAcessoEnum.Administrador, OpcaoMenuEnum.ListarTarefas, TipoPermissaoEnum.Visualizar),
            new PermissaoSistema(PerfilAcessoEnum.Administrador, OpcaoMenuEnum.ListarUsuarios, TipoPermissaoEnum.Visualizar),
            new PermissaoSistema(PerfilAcessoEnum.Administrador, OpcaoMenuEnum.CadastrarUsuario, TipoPermissaoEnum.Criar),
            new PermissaoSistema(PerfilAcessoEnum.Administrador, OpcaoMenuEnum.CadastrarTarefa, TipoPermissaoEnum.Criar),
            new PermissaoSistema(PerfilAcessoEnum.Administrador, OpcaoMenuEnum.AtribuirTarefa, TipoPermissaoEnum.Criar),
        };
    }
}
