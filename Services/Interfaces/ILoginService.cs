using tarefas.Models;

namespace tarefas.Services.Interfaces;

public interface ILoginService
{
    Usuario ObterUsuarioPorEmail(string email);
    UsuarioConsole RealizarLogin(string email, string senha);
}
