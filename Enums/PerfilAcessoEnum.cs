using System.ComponentModel;

namespace tarefas.Enums;
    
public enum PerfilAcessoEnum
{
    [Description("Administrador")]
    Administrador = 1,
    [Description("Funcionário")]
    Funcionario = 2,
    [Description("Gerente")]
    Gerente = 3,
}
