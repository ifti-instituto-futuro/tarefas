using System.ComponentModel;

namespace tarefas.Enums;

public enum OpcaoMenuEnum
{
    Sair = 0,
    [Description("Listar Usuários")]
    ListarUsuarios = 1,
    [Description("Cadastrar Usuário")]
    CadastrarUsuario = 2,
    [Description("Listar Tarefas")]
    ListarTarefas = 3,
    [Description("Cadastrar Tarefa")]
    CadastrarTarefa = 4,
    [Description("Atribuir Tarefa")]
    AtribuirTarefa = 5,
}