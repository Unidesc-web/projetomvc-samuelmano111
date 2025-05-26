# Projeto ASP.NET MVC: Gerenciador de Tarefas (To-Do List)

## Sobre o Projeto

Este é um projeto ASP.NET MVC simples com o tema "Gerenciador de Tarefas" (To-Do List), desenvolvido como parte de uma atividade acadêmica. O objetivo é demonstrar os conceitos fundamentais do padrão MVC (Model-View-Controller) e fornecer uma base para futuras expansões ao longo da disciplina.

Para executar e testar este projeto, você precisará:
1.  Ter o SDK do .NET (versão compatível com ASP.NET MVC Core) instalado em sua máquina.
2.  Criar um novo projeto ASP.NET MVC em seu ambiente local usando o comando `dotnet new mvc -n TodoAppMvc` (ou similar).
3.  Copiar as pastas `Models`, `Controllers` e `Views` (e os arquivos dentro delas) deste pacote para as respectivas pastas do projeto recém-criado em seu ambiente local, substituindo os arquivos de exemplo gerados pelo template.
4.  Após copiar os arquivos, você poderá rodar o projeto a partir do seu ambiente local usando `dotnet run`.

## Funcionalidades Implementadas (Escopo Inicial)

*   **Listar Tarefas:** Visualização de todas as tarefas cadastradas.
*   **Adicionar Nova Tarefa:** Formulário para criar uma nova tarefa.
*   **Editar Tarefa:** Formulário para modificar a descrição e o status de uma tarefa existente.
*   **Marcar Tarefa como Concluída/Pendente:** Alteração do status de uma tarefa.
*   **Excluir Tarefa:** Remoção de uma tarefa da lista (com confirmação).

Os dados são armazenados em uma lista estática em memória no `TarefaController.cs` para simplificar esta fase inicial.
