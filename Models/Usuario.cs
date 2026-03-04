using tarefas.Enums;

namespace tarefas.Models;

public class Usuario
{   
    public Usuario (int id, PerfilAcessoEnum perfilAcesso, string name, string email)
    {
        Id = id;
        PerfilAcesso = perfilAcesso;
        Nome = name;
        Email = email;
        Senha = GerarSenhaAleatoria();
    }

    public int Id { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Nome { get; private set; }
    public string Email { get; private set;} 
    public DateTime DataNascimento { get; private set; }
    public string Senha { get; private set; }

    public void AtualizarDadosCadastrais(string nome, DateTime dataNascimento, string email)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }
    //Sobrecarga de metodos
    public void AtualizarDadosCadastrais(DateTime dataNascimento, string email)
    {
        Email = email;
        DataNascimento = dataNascimento;
    }

    //sobrescrita de metodos
    public override string ToString()
    {
        return $"Nome: {Nome}, Email: {Email}";
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

    //somente utilizado pelo construtor
    private string GerarSenhaAleatoria()
    {
        Guid guidSenha = Guid.NewGuid();
        string senhaAleatoria = guidSenha.ToString().Substring(1, 7);

       return senhaAleatoria + Id.ToString();
    }
}
