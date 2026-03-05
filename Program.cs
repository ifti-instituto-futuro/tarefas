// primeira classe que vai ser lida pelo compilador 


using tarefas.Enums;
using tarefas.Models;

Usuario usuarioGestor = new Usuario(PerfilAcessoEnum.Funcionario, "arthur lanches", "arthur@lanches.com"); 
Usuario usuarioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com"); 

usuarioSubordinado.DefinirSuperiorDiretoDoColaborado(usuarioGestor.Id);

Console.WriteLine(usuarioGestor);
Console.WriteLine(usuarioSubordinado);
