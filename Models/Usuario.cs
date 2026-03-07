using tarefas.Enums;
using tarefas.Model;

namespace tarefas.Models;

public class Usuario
{
    public Usuario (PerfilAcessoEnum perfilAcesso, string name, string email, DateTime dataNascimento)
    {
        Id = Guid.NewGuid().ToString();
        PerfilAcesso = perfilAcesso;
        Email = email;
        GerarSenhaAleatoria();
        Colaborador = CriarColaborador(perfilAcesso, name, dataNascimento);
        PrimeiroAcesso = true;
    }

    public string Id { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Email { get; private set;} 
    public string Senha { get; private set; }
    public bool PrimeiroAcesso { get; private set; }

    public Colaborador Colaborador{ get; private set; }

    public void RealizarPrimeiroAcesso() => PrimeiroAcesso = false;

    public void AtualizarSenha(string novaSenha)
    {
        if (string.IsNullOrEmpty(novaSenha) || novaSenha.Length < 6)
        {
            Console.Error.WriteLine("A senha deve conter pelo menos 6 caracteres.");
            return;
        }
        Senha = novaSenha;
    }

    public string ObterNomeUsuario() => string.IsNullOrEmpty(Colaborador?.Nome) ? "Administrador" : Colaborador.Nome;

    public void DefinirSuperiorDiretoDoColaborado(Colaborador colaborador) => Colaborador.DefinirSuperiorDireto(colaborador);

    public override string ToString()
    {
        string stringColaborador = Colaborador?.ToString();

        return string.IsNullOrEmpty(stringColaborador) 
            ? $"Email: {Email}, Perfil de Acesso: {PerfilAcesso}"
            : Colaborador.Superior is null
                ? stringColaborador + $", Email: {Email}"
                : stringColaborador; 
    }

    private string GerarSenhaAleatoria()
    {
        // var senha = Guid.NewGuid().ToString().Substring(1, 7);
        string senha = "123456";//TODO: descomentar quando resolver o problema de envio de email 
        AtualizarSenha(senha);

        return senha;      
    }

    private Colaborador CriarColaborador(PerfilAcessoEnum perfilAcesso, string nome, DateTime dataNascimento)
    {
        return perfilAcesso switch
        {
            PerfilAcessoEnum.Gerente => new Gerente(Id, nome, dataNascimento),
            PerfilAcessoEnum.Funcionario => new Funcionario(Id, nome, dataNascimento),
            _ => null
        };
    }
}
