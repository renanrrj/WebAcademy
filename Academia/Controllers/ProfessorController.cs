using Academia.Dados;
using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers
{
    public class ProfessorController : Controller
    {
        readonly private ContextoBanco _db;

        public ProfessorController(ContextoBanco db)
        {
            _db = db;
        }

        public IActionResult IndexProf()
        {
            IEnumerable <ProfessorModel> professor = _db.Tb_Professores;
            return View(professor); // "select"
        }
        public IActionResult AdicionarProf()
        {
            return View();
        }
        public IActionResult EditarProf()
        {
            return View();
        }
        public IActionResult ExcluirProf()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult AdicionarProf(ProfessorModel profes)
        {
            if(ModelState.IsValid)
            {
                _db.Tb_Professores.Add(profes);
                _db.SaveChanges();
                return RedirectToAction("IndexProf");
            }
            else { return View(); }
        }
    }
}
