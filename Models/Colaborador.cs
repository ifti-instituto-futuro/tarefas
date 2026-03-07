using tarefas.Enums;
using tarefas.Model;

namespace tarefas.Models;

public abstract class Colaborador
{
    private readonly List<Tarefa> _tarefas = [];

    public Colaborador(string idUsuario, string nome, DateTime dataNascimento)
    {
        Id = Guid.NewGuid().ToString();
        IdUsuario = idUsuario;
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public string Id { get; }
    public string IdUsuario { get; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public Gerente Superior { get; private set; }

    public abstract CargoEnum Cargo { get; protected set; }
    public IReadOnlyList<Tarefa> Tarefas { get  => _tarefas.AsReadOnly(); }

    public void AtualizarDadosPessoais(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public void FinalizarTarefa(string idTarefa)
    {
        var tarefaParaFinalizar = _tarefas?.FirstOrDefault(t => t.Id == idTarefa);
        tarefaParaFinalizar?.Concluir();
    }

    public void IniciarTarefa(string idTarefa)
    {
        var tarefaParaIniciar = _tarefas?.FirstOrDefault(t => t.Id == idTarefa);
        tarefaParaIniciar?.IniciarTarefa();
    }

    public void DefinirSuperiorDireto(Colaborador colaborador)
    {
        if (colaborador is not Gerente gerente)
        {
            Console.Error.WriteLine("O colaborador deve ser um gerente para ser definido como superior direto.");
            return;
        }

        Superior = gerente;
    }

    internal void ReceberTarefa(Tarefa tarefa) => _tarefas.Add(tarefa);

    public List<Tarefa> ListarTarefas() 
    {
        if (Tarefas.Count == 0)
        {
            Console.Error.WriteLine("Nenhuma tarefa atribuída a este colaborador.");
            return [];
        }
    
        return Tarefas.ToList();
    }

    public List<Tarefa> ListarTarefas(TarefaStatusEnum status) 
    {
        if (Tarefas.Count == 0)
        {
            Console.Error.WriteLine("Nenhuma tarefa atribuída a este colaborador.");
            return [];
        }
    
        return Tarefas.Where(t => t.Status == status).ToList();
    }

    public override string ToString()
    {
        return Superior is null
            ? $"Nome: {Nome}, Cargo: {Cargo}"
            : $"Nome: {Nome}, Cargo: {Cargo}, Gestor: {Superior.Nome}";
    } 
}
