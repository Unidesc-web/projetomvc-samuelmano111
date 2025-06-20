# AluguelCarros

Sistema de aluguel de carros desenvolvido em ASP.NET MVC para a disciplina de programação.

## Funcionalidades

- **Gerenciamento de Categorias de Carros**: Criar, listar, editar e excluir categorias (Econômico, Intermediário, SUV, Luxo)
- **Gerenciamento de Carros**: Cadastrar, listar, editar e excluir carros da frota
- **Gerenciamento de Clientes**: Cadastrar, listar, editar e excluir clientes
- **Gerenciamento de Locações**: Registrar novas locações, controlar status e devolução
- **Visualização de Carros Disponíveis**: Interface pública para visualizar carros disponíveis para locação

## Tecnologias Utilizadas

- ASP.NET Core 8.0 MVC
- Entity Framework Core (In-Memory Database)
- Bootstrap 5
- HTML5, CSS3, JavaScript

## Estrutura do Projeto

```
AluguelCarros/
├── Controllers/
│   ├── HomeController.cs
│   ├── CategoriasCarrosController.cs
│   ├── CarrosController.cs
│   ├── ClientesController.cs
│   ├── LocacoesController.cs
│   └── CarrosDisponiveisController.cs
├── Models/
│   ├── CategoriaCarro.cs
│   ├── Carro.cs
│   ├── Cliente.cs
│   └── Locacao.cs
├── Data/
│   └── AluguelContext.cs
├── Views/
│   ├── Home/
│   ├── CategoriasCarros/
│   ├── Carros/
│   ├── Clientes/
│   ├── Locacoes/
│   ├── CarrosDisponiveis/
│   └── Shared/
└── wwwroot/
```

## Como Executar

1. Certifique-se de ter o .NET 8.0 SDK instalado
2. Clone o repositório
3. Navegue até a pasta do projeto
4. Execute o comando: `dotnet run`
5. Acesse `https://localhost:5001` no navegador

## Funcionalidades Implementadas

### Modelos
- **CategoriaCarro**: Representa as categorias de carros (Econômico, Intermediário, SUV, Luxo)
- **Carro**: Representa os carros da frota com marca, modelo, ano, placa, cor, preço por dia e categoria
- **Cliente**: Representa os clientes com dados pessoais e de contato
- **Locacao**: Representa as locações com cliente, carro, datas e valor total

### Controladores
- **CategoriasCarrosController**: CRUD completo para categorias de carros
- **CarrosController**: CRUD completo para carros da frota
- **ClientesController**: CRUD completo para clientes
- **LocacoesController**: Gerenciamento de locações (criar, listar, editar status)
- **CarrosDisponiveisController**: Visualização pública de carros disponíveis

### Relacionamentos
- Uma categoria pode ter vários carros (1:N)
- Um carro pertence a uma categoria (N:1)
- Um cliente pode ter várias locações (1:N)
- Um carro pode ter várias locações (1:N)
- Uma locação pertence a um cliente e um carro (N:1)

### Regras de Negócio
- Carros ficam indisponíveis quando alugados
- Cálculo automático do valor total da locação baseado no preço por dia
- Controle de status das locações (Ativa, Finalizada, Cancelada)
- Carros voltam a ficar disponíveis quando a locação é finalizada

## Dados Iniciais

O sistema vem com dados de exemplo pré-carregados:
- 4 categorias de carros
- 4 carros de exemplo
- 2 clientes de exemplo

## Autor

Projeto desenvolvido como atividade acadêmica (OAT) para a disciplina de programação.

