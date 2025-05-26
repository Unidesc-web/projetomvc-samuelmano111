using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAppMvc.Models; // Atualizado para o namespace correto do projeto

namespace TodoAppMvc.Controllers
{
    public class TarefaController : Controller
    {
        // Lista estática para simular um banco de dados em memória
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;

        // GET: /Tarefa/ ou /Tarefa/Index
        public IActionResult Index()
        {
            // Ordena as tarefas: primeiro as pendentes, depois as concluídas, e então por ID.
            return View(_tarefas.OrderBy(t => t.Concluida).ThenBy(t => t.Id).ToList());
        }

        // GET: /Tarefa/Criar
        public IActionResult Criar()
        {
            return View();
        }

        // POST: /Tarefa/Criar
        [HttpPost]
        [ValidateAntiForgeryToken] // Boa prática para proteger contra ataques CSRF
        public IActionResult Criar([Bind("Descricao")] Tarefa tarefa) // Bind para evitar overposting
        {
            if (ModelState.IsValid)
            {
                tarefa.Id = _proximoId++;
                tarefa.Concluida = false; // Novas tarefas começam como pendentes
                _tarefas.Add(tarefa);
                return RedirectToAction(nameof(Index)); // Redireciona para a lista de tarefas
            }
            return View(tarefa); // Se o modelo não for válido, retorna para a view de criação com os erros
        }

        // GET: /Tarefa/AlternarStatus/5
        public IActionResult AlternarStatus(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound(); // Retorna 404 se a tarefa não for encontrada
            }
            tarefa.Concluida = !tarefa.Concluida; // Alterna o status
            return RedirectToAction(nameof(Index));
        }

        // GET: /Tarefa/Excluir/5
        public IActionResult Excluir(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa); // Passa a tarefa para a View de confirmação de exclusão
        }

        // POST: /Tarefa/ConfirmarExclusao/5  (Nome da action para o POST)
        [HttpPost, ActionName("Excluir")] // ActionName especifica que o método POST para /Tarefa/Excluir/5 é este
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id) 
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
            return RedirectToAction(nameof(Index));
        }

        // Métodos para Editar (GET e POST) podem ser adicionados em uma próxima iteração
        // GET: /Tarefa/Editar/5
        public IActionResult Editar(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        // POST: /Tarefa/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("Id,Descricao,Concluida")] Tarefa tarefaAtualizada)
        {
            if (id != tarefaAtualizada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tarefaExistente = _tarefas.FirstOrDefault(t => t.Id == id);
                    if (tarefaExistente == null)
                    {
                        return NotFound();
                    }
                    tarefaExistente.Descricao = tarefaAtualizada.Descricao;
                    tarefaExistente.Concluida = tarefaAtualizada.Concluida;
                }
                catch (Exception /* ex */)
                {
                    // Logar o erro (ex) se necessário
                    // Poderia verificar se a tarefa ainda existe, etc.
                    // Por simplicidade, se houver um erro não esperado, apenas não atualizamos.
                    if (_tarefas.All(t => t.Id != id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Re-throw se for um erro inesperado não relacionado à busca
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaAtualizada);
        }
    }
}

