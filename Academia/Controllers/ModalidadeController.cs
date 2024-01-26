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
//--------------------LER----------------------------------------------------------
        [HttpGet]
        public IActionResult IndexModali()
        {
            IEnumerable<ModalidadeModel> modalidade = _db.Tb_Modalidades;
            return View(modalidade);
        }

//--------------------ADICIONAR-------------------------------------------------------------
        [HttpGet]
        public IActionResult AdicionarModali()
        {
            return View();
        }

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

//---------------------------EDITAR---------------------------------------------------------
        [HttpGet]
        public IActionResult EditarModali(int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            ModalidadeModel modalida = _db.Tb_Modalidades.First(x => x.Id == id);

            if(modalida == null)
            {
                return NotFound();
            }
            return View(modalida);
        }

        [HttpPost]
        public IActionResult EditarModali(ModalidadeModel modalida)
        {
            if (ModelState.IsValid)
            {
                _db.Tb_Modalidades.Update(modalida);
                _db.SaveChanges();
                return RedirectToAction("IndexModali");
            }
            else { return View(modalida); }
        }

        //----------------------------EXCLUIR-------------------------------------------------------
        [HttpGet]
        public IActionResult ExcluirModali(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ModalidadeModel modalidade= _db.Tb_Modalidades.FirstOrDefault(x => x.Id == id);

            if (modalidade == null)
            {
                return NotFound();
            }
            return View(modalidade);
        }

        [HttpPost]
        public IActionResult ExcluirModali(ModalidadeModel modalidad)
        {
            if (modalidad == null)
            {
                return NotFound();
            }
            _db.Tb_Modalidades.Remove(modalidad);
            _db.SaveChanges();
            return RedirectToAction("IndexModali");
        }
        //------------------------------------------------------------------------------------------

    }
}
