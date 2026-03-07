# Sistema de Tarefas

## 📁 Estrutura de Arquivos

```text
tarefas/
├── Enums/
│   ├── CargoEnum.cs
│   ├── OpcaoMenuEnum.cs
│   ├── PerfilAcessoEnum.cs
│   ├── TarefaStatusEnum.cs
│   ├── TipoPermissaoEnum.cs
│   └── TipoTarefaEnum.cs
│
├── Handlers/
│   ├── TarefaHandler.cs
│   └── UsuarioHandler.cs
│
├── Helpers/
│   └── EnumHelper.cs
│
├── Mock/
│   ├── PermissaoFactory.cs
│   └── UsuarioFactory.cs
│
├── Models/
│   ├── Colaborador.cs          (abstrato)
│   ├── Funcionario.cs
│   ├── Gerente.cs
│   ├── PermissaoSistema.cs
│   ├── Tarefa.cs
│   ├── Usuario.cs
│   └── UsuarioConsole.cs
│
├── Services/
│   ├── LoginService.cs
│   └── TarefaService.cs
│
├── UI/
│   ├── AplicacaoUI.cs
│   ├── LoginUI.cs
│   └── MenuUI.cs
│
└── Program.cs
```

---

## 📐 Diagrama de Classes UML

```mermaid
classDiagram
    direction TB

    class CargoEnum {
        <<enumeration>>
        Gerente
        Funcionario
    }

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

    class TarefaStatusEnum {
        <<enumeration>>
        Cadastrada
        EmAndamento
        Concluida
    }

    class OpcaoMenuEnum {
        <<enumeration>>
        Sair
        ListarUsuarios
        CadastrarUsuario
        ListarTarefas
        CadastrarTarefa
        AtribuirTarefa
    }

    class TipoPermissaoEnum {
        <<enumeration>>
        Visualizar
        Criar
        Editar
        Excluir
    }

    class Tarefa {
        +string Id
        +string Titulo
        +string Descricao
        +TipoTarefaEnum Tipo
        +TarefaStatusEnum Status
        +DateTime DataCriacao
        +DateTime DataFinalizacao
        +string IdGerenteResponsavelCadastro
        +string IdFuncionarioResponsavel
        +Atribuir(string) void
        +IniciarTarefa() void
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
        +CargoEnum Cargo
        +IReadOnlyList Tarefas
        +AtualizarDadosPessoais(string, DateTime) void
        +DefinirSuperiorDireto(Colaborador) void
        +IniciarTarefa(string) void
        +FinalizarTarefa(string) void
        ~ReceberTarefa(Tarefa) void
    }

    class Funcionario {
        +CargoEnum Cargo
    }

    class Gerente {
        +CargoEnum Cargo
        +AtribuirTarefa(Colaborador, Tarefa) void
    }

    class Usuario {
        +string Id
        +PerfilAcessoEnum PerfilAcesso
        +string Email
        +string Senha
        +bool PrimeiroAcesso
        +Colaborador Colaborador
        +AtualizarDadosCadastrais(string, DateTime, string) void
        +AtualizarSenha(string) void
        +MarcarPrimeiroAcessoRealizado() void
        +DefinirSuperiorDiretoDoColaborado(Colaborador) void
        +ToString() string
        -CriarColaborador(PerfilAcessoEnum) Colaborador
        -GerarSenhaAleatoria() string
    }

    class PermissaoSistema {
        +PerfilAcessoEnum PerfilAcesso
        +OpcaoMenuEnum OpcaoMenu
        +TipoPermissaoEnum TipoPermissao
    }

    class UsuarioConsole {
        +string IdUsuario
        +string Nome
        +PerfilAcessoEnum PerfilAcesso
        +CargoEnum Cargo
        +List Permissoes
        +PossuiPermissao(OpcaoMenuEnum, TipoPermissaoEnum) bool
        +ObterOpcoesDisponiveis() List
    }

    Colaborador <|-- Funcionario
    Colaborador <|-- Gerente
    Usuario *-- Colaborador
    Colaborador --> Gerente
    Colaborador o-- Tarefa
    UsuarioConsole o-- PermissaoSistema
    UsuarioConsole ..> PerfilAcessoEnum
    UsuarioConsole ..> CargoEnum
    Usuario ..> PerfilAcessoEnum
    Tarefa ..> TipoTarefaEnum
    Tarefa ..> TarefaStatusEnum
    Colaborador ..> CargoEnum
    PermissaoSistema ..> PerfilAcessoEnum
    PermissaoSistema ..> OpcaoMenuEnum
    PermissaoSistema ..> TipoPermissaoEnum
```

---

## 🏗️ Arquitetura em Camadas

```text
┌─────────────────────────────────────┐
│              Program.cs             │  ← Inicializa listas e chama UI
└──────────────────┬──────────────────┘
                   │
┌──────────────────▼──────────────────┐
│               UI Layer              │
│  AplicacaoUI  LoginUI  MenuUI       │  ← Renderização e loops de tela
└──────────────────┬──────────────────┘
                   │
┌──────────────────▼──────────────────┐
│            Handlers Layer           │
│   UsuarioHandler   TarefaHandler    │  ← Leitura e validação de inputs
└──────────────────┬──────────────────┘
                   │
┌──────────────────▼──────────────────┐
│            Services Layer           │
│    LoginService    TarefaService    │  ← Regras de negócio
└──────────────────┬──────────────────┘
                   │
┌──────────────────▼──────────────────┐
│             Models Layer            │
│  Usuario  Colaborador  Tarefa  ...  │  ← Domínio da aplicação
└─────────────────────────────────────┘
```

---

## 🔐 Permissões por Perfil

| Opção de Menu     | Funcionário    | Gerente        | Administrador  |
|-------------------|:--------------:|:--------------:|:--------------:|
| Listar Tarefas    | ✅ Visualizar  | ✅ Visualizar  | ✅ Visualizar  |
| Cadastrar Tarefa  | ❌             | ✅ Criar       | ✅ Criar       |
| Atribuir Tarefa   | ❌             | ✅ Criar       | ✅ Criar       |
| Listar Usuários   | ❌             | ✅ Visualizar  | ✅ Visualizar  |
| Cadastrar Usuário | ❌             | ❌             | ✅ Criar       |
