using tarefas.Enums;
using tarefas.Models;

namespace tarefas.Model;

public class Gerente : Colaborador
{
    public Gerente(string idUsuario, string nome, DateTime dataNascimento) : base(idUsuario, nome, dataNascimento) { }

    public override CargoEnum Cargo { get; protected set; } = CargoEnum.Gerente;

    public void AtribuirTarefa(Colaborador colaborador, string titulo, string descricao, TipoTarefaEnum tipo)
    {
        if (colaborador is not Funcionario && colaborador is not Gerente)
        {
            Console.Error.WriteLine("A tarefa só pode ser atribuída a um funcionário ou a outro gerente.");
            return;
        }

        var estaSubordinado = Id == colaborador?.Superior?.Id;
        if (!estaSubordinado)
        {
            Console.Error.WriteLine("O colaborador deve ser subordinado ao gerente para receber uma tarefa.");
            return;
        }

        colaborador.AdicionarTarefa(titulo, descricao, tipo, Id);
    }
}