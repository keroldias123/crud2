using crud2.Data;
using crud2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crud2.Views.Pessoa
{
    public class IndexModel : Controller
    {
        private readonly  Contexto _context;

        public void OnGet()
        {
        }
        [HttpPost]
        public async Task<IActionResult> CreatePessoa(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddPessoaAsync(pessoa);
                    ViewBag.Message = "Pessoa criada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Erro ao criar pessoa: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Error = "Dados inválidos.";
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditPessoa(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pessoaExistente = await _context.GetPessoaByIdAsync(pessoa.Id);
                    if (pessoaExistente != null)
                    {
                        await _context.UpdatePessoaAsync(pessoa);
                        ViewBag.Message = "Pessoa editada com sucesso!";
                        return RedirectToAction("Index");
                    }
                    ViewBag.Error = "Pessoa não encontrada.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Erro ao editar pessoa: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Error = "Dados inválidos.";
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            try
            {
                await _context.DeletePessoaAsync(id);
                ViewBag.Message = "Pessoa excluída com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao excluir pessoa: {ex.Message}";
            }
            return View("Index");
        }


    }
}
