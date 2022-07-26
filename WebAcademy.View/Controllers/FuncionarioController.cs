using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAcademy.Model;

namespace WebAcademy.View.Controllers
{
    public class FuncionarioController : Controller
    {
        db_WebAcademyContext odb; // contexto
        public FuncionarioController ()
        {
            odb = new db_WebAcademyContext (); // construiu contexto
        }

        // GET: Funcionario
        public ActionResult Index()
        {
            List<TbFuncionario> oListaFun = odb.TbFuncionario.ToList();
            return View(oListaFun);
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            TbFuncionario ?oFun = odb.TbFuncionario.Find(id);
            return View(oFun);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbFuncionario oCat)
        {
            try 
            {
                odb.TbFuncionario.Add(oCat);
                odb.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            TbFuncionario ?oCat = odb.TbFuncionario.Find(id);
            return View(oCat);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbFuncionario oCat)    
        {
            var oCatBanco = odb.TbFuncionario.Find(id);
            oCatBanco.FunNome = oCat.FunNome;
            oCatBanco.FunDataNasc = oCat.FunDataNasc;
            oCatBanco.FunCpf = oCat.FunCpf;
            oCatBanco.FunEmail = oCat.FunEmail;
            oCatBanco.FunModalidade = oCat.FunModalidade;
            oCatBanco.FunCategoria = oCat.FunCategoria;
            odb.Entry(oCatBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            odb.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            TbFuncionario ?oFun = odb.TbFuncionario.Find(id);
            odb.Entry(oFun).State = EntityState.Deleted;
            odb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: Funcionario/Delete/5
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
