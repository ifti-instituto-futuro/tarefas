using tarefas.Enums;
using tarefas.Models;

namespace tarefas.Model;

public class Funcionario : Colaborador
{
    public Funcionario(string idUsuario, string nome, DateTime dataNascimento) : base(idUsuario, nome, dataNascimento) { }

    public override CargoEnum Cargo { get; protected set; } = CargoEnum.Funcionario;
}