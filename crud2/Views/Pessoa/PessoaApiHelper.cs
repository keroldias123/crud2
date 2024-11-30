using crud2.Data;
using crud2.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud2.Views.Pessoa
{
    public class PessoaApiHelper : Controller
    {
        private readonly Contexto _context;

        public PessoaApiHelper(Contexto context)
        {
            _context = context;
        }

        // Método para criar uma nova pessoa
        [HttpPost]
        public async Task<IActionResult> CreatePessoa(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddPessoaAsync(pessoa);
                    return RedirectToAction("Index", "Pessoa"); // Redireciona para a página principal após salvar
                }
                return View(pessoa); // Retorna para a view com a pessoa, caso o modelo não seja válido
            }
            catch (Exception ex)
            {
                // Erro ao salvar a pessoa
                ModelState.AddModelError("", $"Erro ao criar pessoa: {ex.Message}");
                return View(pessoa);
            }
        }

        // Método para editar uma pessoa
        [HttpPost]
        public async Task<IActionResult> EditPessoa(PessoaModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pessoaExistente = await _context.GetPessoaByIdAsync(pessoa.Id);
                    if (pessoaExistente != null)
                    {
                        await _context.UpdatePessoaAsync(pessoa);
                        return RedirectToAction("Index", "Pessoa"); // Redireciona para a página principal após editar
                    }
                    ModelState.AddModelError("", "Pessoa não encontrada.");
                }
                return View(pessoa); // Retorna a view com erro se não encontrar a pessoa ou se dados inválidos
            }
            catch (Exception ex)
            {
                // Erro ao editar a pessoa
                ModelState.AddModelError("", $"Erro ao editar pessoa: {ex.Message}");
                return View(pessoa);
            }
        }

        // Método para excluir uma pessoa
        [HttpPost]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            try
            {
                await _context.DeletePessoaAsync(id);
                return RedirectToAction("Index", "Pessoa"); // Redireciona para a página principal após excluir
            }
            catch (Exception ex)
            {
                // Erro ao excluir a pessoa
                ModelState.AddModelError("", $"Erro ao excluir pessoa: {ex.Message}");
                return RedirectToAction("Index", "Pessoa"); // Redireciona mesmo em caso de erro
            }
        }

    }
}
