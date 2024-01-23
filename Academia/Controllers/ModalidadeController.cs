using Academia.Dados;
using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers
{
    public class ModalidadeController : Controller
    {
        readonly private ContextoBanco _db;

        public ModalidadeController(ContextoBanco db)
        {
            _db = db;
        }

        public IActionResult IndexModali()
        {
            IEnumerable<ModalidadeModel> modalidade = _db.Tb_Modalidades;
            return View(modalidade);
        }
        public IActionResult AdicionarModali()
        {
            return View();
        }
        public IActionResult EditarModali()
        {
            return View();
        }
        public IActionResult ExcluirModali()
        {
            return View();
        }
    }
}
