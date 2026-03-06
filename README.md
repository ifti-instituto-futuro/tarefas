Revisando: Encapsulamento
    - modificadores de acesso para as propriedades da classe
    - Métodos são a forma que as classes se comportam
    - construtores para encapsular a logica de criação da classe 
    - Metodo GerarSenhaAleatoria() sendo chamado dentro do construtor para inicializar uma senha aleatoria quando o usuario for cadastrado
    - sobrecarga e sobrescrita de métodos


Composição: permite relação entre classes 
    todos os usuarios são colaboradores, o sistema não deve permitir que mais de um usuario seja criado para cada colaborador 

TODO: - Criar a classe Colaborador
    - irá definir o cargo -- talvez mais tarde
    - irá definir o superior direto daquele colaborador (autoRelacionamento)

tarefas/
├── Enums/
│   ├── PerfilAcessoEnum.cs
│   └── TipoTarefaEnum.cs       ← novo
├── Models/
│   ├── Colaborador.cs          ← refatorado (abstrato)
│   ├── Funcionario.cs          ← novo
│   ├── Gerente.cs              ← novo
│   ├── Tarefa.cs               ← novo
│   └── Usuario.cs              ← refatorado
└── Program.cs                  ← atualizado


```mermaid
classDiagram
    direction TB

    class PerfilAcessoEnum {
        <<enumeration>>
        Administrador
        Funcionario
        Gerente
    }

    class TipoTarefaEnum {
        <<enumeration>>
        Simples
        Urgente
        Recorrente
    }

    class Tarefa {
        +string Id
        +string Titulo
        +string Descricao
        +TipoTarefaEnum Tipo
        +DateTime DataCriacao
        +bool Concluida
        +Concluir() void
        +ToString() string
    }

    class Colaborador {
        <<abstract>>
        +string Id
        +string IdUsuario
        +string Nome
        +DateTime DataNascimento
        +Gerente Superior
        +List Tarefas
        +ObterCargo() string
        +AtualizarDadosPessoais(string, DateTime) void
        +DefinirSuperiorDireto(Colaborador) void
        +ListarTarefas() void
        +ReceberTarefa(Tarefa) void
        +IniciarTarefa(string) void
    }

    class Funcionario {
        +ObterCargo() string

    }

    class Gerente {
        +ObterCargo() string
        +AtribuirTarefa(Colaborador, Tarefa) void
    }

    class Usuario {
        +string Id
        +PerfilAcessoEnum PerfilAcesso
        +string Email
        +string Senha
        +Colaborador Colaborador
        +AtualizarDadosCadastrais(string) void
        +AtualizarSenha(string) void
        +DefinirSuperiorDiretoDoColaborado(Colaborador) void
        +ToString() string
        -GerarSenhaAleatoria() string
    }

    Colaborador <|-- Funcionario
    Colaborador <|-- Gerente
    Usuario *-- Colaborador
    Colaborador --> Gerente
    Colaborador o-- Tarefa
    Usuario ..> PerfilAcessoEnum
    Tarefa ..> TipoTarefaEnum
```