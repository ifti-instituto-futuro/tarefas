using tarefas.Mock;
using tarefas.Models;
using tarefas.Services;
using tarefas.Services.Interfaces;
using tarefas.UI;

//APENAS UM TESTE
List<Usuario> usuarios = UsuarioFactory.CriarUsuarioMock();
List<PermissaoSistema> permissoes = PermissaoFactory.CriarPermissoesMock();

ILoginService loginService = new LoginService(usuarios, permissoes);

var loginInput = LoginUI.RenderizarEObterInputsLogin();

loginService.RealizarLogin(loginInput.Email, loginInput.Senha);

var loginInputTeste = LoginUI.RenderizarEObterInputsLogin();

loginService.RealizarLogin(loginInputTeste.Email, loginInputTeste.Senha);
