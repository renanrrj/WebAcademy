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
        public IActionResult EditarProf(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            ProfessorModel professor = _db.Tb_Professores.FirstOrDefault(p => p.Id == id);

            if (professor == null) 
            {
                return NotFound();
            }
            return View(professor);
        }
        public IActionResult ExcluirProf(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ProfessorModel professor = _db.Tb_Professores.FirstOrDefault(x => x.Id == id);

            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
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

        [HttpPost]
        public IActionResult EditarProf(ProfessorModel professor)
        {
            if(ModelState.IsValid)
            {
                _db.Tb_Professores.Update(professor);
                _db.SaveChanges();
                return RedirectToAction("IndexProf");
            }
            else {return View(professor);}
        }

        [HttpPost]
        public IActionResult ExcluirProf(ProfessorModel professor)
        {
            if (professor== null)
            {
                return NotFound();
            }
            _db.Tb_Professores.Remove(professor);
            _db.SaveChanges();
            return RedirectToAction("IndexProf");

        }
    }
}
