using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tarefas.UI;
    
public static class LoginUI
{
    public record LoginInput(string Email, string Senha);
    public record MudarSenhaInput(string NovaSenha, string SenhaConfirmacao);

    public static LoginInput RenderizarEObterInputsLogin()
    {
        Console.WriteLine("=== Tela de Login ===");
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? string.Empty;
        Console.Write("Senha: ");
        var senha = Console.ReadLine() ?? string.Empty;
    
        return new LoginInput(email.Trim(), senha);
    }

    public static MudarSenhaInput ExibirTelaMudarSenhaEObterInputs()
    {
        Console.WriteLine("=== Tela de Mudança de Senha ===");
        Console.Write("Nova senha: ");
        var novaSenha = Console.ReadLine() ?? string.Empty;
        Console.Write("Confirmação da nova senha: ");
        var senhaConfirmacao = Console.ReadLine() ?? string.Empty;

        return new MudarSenhaInput(novaSenha, senhaConfirmacao);
    }
}
