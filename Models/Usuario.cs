using tarefas.Enums;

namespace tarefas.Models;

public class Usuario
{
    public Usuario (PerfilAcessoEnum perfilAcesso, string name, string email)
    {
        Id = Guid.NewGuid().ToString();
        PerfilAcesso = perfilAcesso;
        Nome = name;
        Email = email;
        Senha = GerarSenhaAleatoria();
        Colaborador = new Colaborador(idUsuario:Id);
    }

    public string Id { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Nome { get; private set; }
    public string Email { get; private set;} 
    public DateTime DataNascimento { get; private set; }
    public string Senha { get; private set; }

    public Colaborador Colaborador{ get; private set; }

    public void AtualizarDadosCadastrais(string nome, DateTime dataNascimento, string email)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }

    public void AtualizarSenha(string novaSenha)
    {
        if (string.IsNullOrEmpty(novaSenha) || novaSenha.Length < 6)
        {
            Console.Error.WriteLine("A senha deve conter pelo menos 6 caracteres.");
            return;
        }

        Senha = novaSenha;
    }

    public void DefinirSuperiorDiretoDoColaborado(string id) => Colaborador.DefinirSuperiorDireto(id);

    public override string ToString()
    {
        return string.IsNullOrEmpty(Colaborador.IdSuperior) 
            ? $"Nome: {Nome}, Email: {Email}"
            : $"Nome: {Nome}, Email: {Email}, Código do Gestor: {Colaborador.ObterCodigoGerenteResponsavelFormatado()}";
    } 

    //somente utilizado pelo construtor
    private string GerarSenhaAleatoria()
    {
        Guid guidSenha = Guid.NewGuid();
        string senhaAleatoria = guidSenha.ToString().Substring(1, 7);

       return senhaAleatoria;
    }
}
