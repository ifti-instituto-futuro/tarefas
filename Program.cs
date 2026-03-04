// primeira classe que vai ser lida pelo compilador 


using tarefas.Enums;
using tarefas.Models;

//new significa que algum objeto foi instanciado dentro da memortia HEAP ou seja a variável apenas possui o endere;co de memoria para aquele objeto
Usuario usuario = new Usuario(1, PerfilAcessoEnum.Administrador, "João", "joao@email.com"); // endereco1

usuario.AtualizarDadosCadastrais(new DateTime(1990, 5, 20), "emailgerenerico@gen.com"); // endereco1
usuario.AtualizarDadosCadastrais("Maria", DateTime.Now, "maria@email.com"); // endereco1


