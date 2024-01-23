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

        [HttpGet]
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

        //------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult AdicionarModali(ModalidadeModel modali)
        {
            if (ModelState.IsValid)
            {
                _db.Tb_Modalidades.Add(modali);
                _db.SaveChanges();
                return RedirectToAction("IndexModali");
            }
            else { return View(); }

        }
    }
}
