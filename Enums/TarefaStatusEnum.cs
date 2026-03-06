using System.ComponentModel;

namespace tarefas.Enums;
    
public enum TarefaStatusEnum
{
    [Description("Cadastrada")]
    Cadatrada, 
    [Description("Em Andamento")]
    EmAndamento,
    [Description("Concluída")]
    Concluida    
}