using tarefas.Enums;
using tarefas.Models;

namespace tarefas.Mock;

public static class UsuarioFactory
{
    public static List<Usuario> CriarUsuarioMock()
    {
        var usuarioGerente = new Usuario(PerfilAcessoEnum.Gerente, "Arthur", "arthur@email.com", new DateTime(1985, 5, 10));
        var usuarioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com", new DateTime(1990, 1, 1));
        var usuarioSubordinado2 = new Usuario(PerfilAcessoEnum.Funcionario, "Maria", "maria@email.com", new DateTime(1992, 3, 15));

        usuarioSubordinado.DefinirSuperiorDiretoDoColaborado(usuarioGerente.Colaborador);
        usuarioSubordinado2.DefinirSuperiorDiretoDoColaborado(usuarioGerente.Colaborador);

        var administrador = new Usuario(PerfilAcessoEnum.Administrador, null, "adm@email.com", new DateTime(1980, 1, 1));

        return new List<Usuario> { usuarioGerente, usuarioSubordinado, usuarioSubordinado2, administrador };
    }
}