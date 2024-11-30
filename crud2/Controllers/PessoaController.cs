using Microsoft.AspNetCore.Mvc;

namespace crud2.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
