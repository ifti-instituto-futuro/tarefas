using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using tarefas.Enums;
using tarefas.Helpers;

namespace tarefas.Models;


public class Tarefa
{

    public Tarefa (string titulo, string descricao, TipoTarefaEnum tipo, string idGerente)
    {
        Id = Guid.NewGuid().ToString();
        IdGerenteResponsavelCadastro = idGerente;
        Titulo = titulo;
        Descricao = descricao;
        Tipo = tipo;
        DataCriacao = DateTime.Today;
        Status = TarefaStatusEnum.Cadatrada;
    }

    public string Id { get; } 
    public string Titulo { get; }
    public TarefaStatusEnum Status {get; private set;}
    public string Descricao { get; }
    public TipoTarefaEnum Tipo { get; }
    public DateTime DataCriacao { get; }
    public DateTime DataFinalizacao { get; private set; }
    public string IdGerenteResponsavelCadastro { get; private set; }
    public string IdFuncionarioResponsavel { get; private set; }

    public void AtribuirFuncionarioResponsavel(string idFuncionario) => IdFuncionarioResponsavel = idFuncionario;

    public void Concluir()
    {
        Status = TarefaStatusEnum.Concluida;
        DataFinalizacao = DateTime.Today;
    }

    public void IniciarTarefa() => Status = TarefaStatusEnum.EmAndamento;

    public override string ToString()
    {
        return $"Título: {Titulo}, Descrição: {Descricao}, Tipo: {Tipo}, Data de Criação: {DataCriacao.ToShortDateString()}, Status: {Status.GetEnumDescription()}";
    }
}
