// primeira classe que vai ser lida pelo compilador 


using tarefas.Enums;
using tarefas.Model;
using tarefas.Models;

Usuario usuarioGestor = new Usuario(PerfilAcessoEnum.Gerente, "arthur lanches", "arthur@lanches.com", DateTime.Parse("1990-01-01")); 
Usuario usuarioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com", DateTime.Parse("1990-01-01")); 
Usuario administrador = new Usuario(PerfilAcessoEnum.Administrador,  string.Empty, "adm@email.com", DateTime.Now); 

usuarioSubordinado.DefinirSuperiorDiretoDoColaborado(usuarioGestor.Colaborador);

if (usuarioGestor.Colaborador is Gerente gerente)
    gerente.AtribuirTarefa(usuarioSubordinado.Colaborador, "Finalizar relatório", "Finalizar o relatório mensal de vendas", TipoTarefaEnum.Recorrente);

Console.WriteLine(usuarioGestor);
Console.WriteLine(usuarioSubordinado);

usuarioSubordinado.Colaborador.ListarTarefas().ForEach(tarefa => Console.WriteLine(tarefa));
