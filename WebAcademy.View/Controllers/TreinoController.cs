using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAcademy.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAcademy.View.Controllers
{
    public class TreinoController : Controller
    {
        db_WebAcademyContext db;

        public TreinoController()
        {
            db = new db_WebAcademyContext();
        }
        // GET: TreinoController
        public ActionResult View()
        {
            List<TbTreino> oListTre = db.TbTreino.ToList();
            return View(oListTre);
        }

        // GET: TreinoController/Details/5
        public ActionResult Details(int id)
        {
            TbTreino ?oTre = db.TbTreino.Find(id);
            return View(oTre);
        }

        // GET: TreinoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbTreino oCatTre)
        {
            try
            {
                db.TbTreino.Add(oCatTre);                      
                db.SaveChanges();                               
                return RedirectToAction(nameof(View));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreinoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TreinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbTreino oCat)
        {
            var oCatTre = db.TbTreino.Find(id);
            oCatTre.TreDataHora = oCat.TreDataHora;
            oCatTre.TreModalidade = oCat.TreModalidade;
            db.Entry(oCatTre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(View));            
        }

        // GET: TreinoController/Delete/5
        public ActionResult Delete(int id)
        {
            TbTreino? oTre = db.TbTreino.Find(id);
            db.Entry(oTre).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction(nameof(View));
        }

        // POST: TreinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
