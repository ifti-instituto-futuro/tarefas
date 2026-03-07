using tarefas.Models;
using tarefas.Services.Interfaces;
using tarefas.UI;

namespace tarefas.Services;

public class LoginService(List<Usuario> usuarios, List<PermissaoSistema> permissoesSistema) : ILoginService
{
    public Usuario ObterUsuarioPorEmail(string email) => usuarios.FirstOrDefault(u => u.Email.Equals(email));

    public UsuarioConsole RealizarLogin(string email, string senha)
    {
        var usuario = ObterUsuarioPorEmail(email);
        if (usuario is null || usuario.Senha != senha)
        {
            Console.Error.WriteLine("Email ou senha inválidos.");
            return null;
        }

        var permissoesUsuario = permissoesSistema.Where(p => p.PerfilAcesso.Equals(usuario.PerfilAcesso)).ToList();
        var usuarioConsole = new UsuarioConsole(usuario.Id, usuario.ObterNomeUsuario(), usuario.PerfilAcesso, usuario.Colaborador?.Cargo, permissoesUsuario);

        if(usuarioConsole is not null && usuario.PrimeiroAcesso)
           AlterarSenhaPrimeiroAcesso(usuario);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Login realizado com sucesso.");
        
        return usuarioConsole;
    }

    private void AlterarSenhaPrimeiroAcesso(Usuario usuario)
    {
        Console.WriteLine("Primeiro acesso identificado, vamos alterar sua senha");
        var inputsMudancaSenha = LoginUI.ExibirTelaMudarSenhaEObterInputs();
        do
        {
            if(inputsMudancaSenha.NovaSenha != inputsMudancaSenha.SenhaConfirmacao)
            {
                Console.Error.WriteLine("A nova senha e a confirmação não coincidem. Tente novamente.");
                inputsMudancaSenha = LoginUI.ExibirTelaMudarSenhaEObterInputs();
                continue;
            }
        }
        while(inputsMudancaSenha.NovaSenha != inputsMudancaSenha.SenhaConfirmacao);

        usuario.AtualizarSenha(inputsMudancaSenha.NovaSenha);
        usuario.RealizarPrimeiroAcesso();
    }
}
