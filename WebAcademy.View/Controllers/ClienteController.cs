using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAcademy.Model;

namespace WebAcademy.View.Controllers
{
    public class ClienteController : Controller
    {
        db_WebAcademyContext db;                                // Aqui, cria-se o contexto

        public ClienteController()                              // Aqui, Cria-se o contrutor do contexto
        {
            db = new db_WebAcademyContext();
        }
        // GET: ClienteController
        public ActionResult Index()
        {
            List <TbCliente> oListCli = db.TbCliente.ToList();  // Seleciona do TbCliente e coloca na List "oListCli"
            return View(oListCli);                              // Retorna "oListClie"
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            TbCliente ?oCli = db.TbCliente.Find(id);
            return View(oCli);
        }

        // GET: ClienteController/Create
        public ActionResult Create()                            // aqui chama a página create
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbCliente oCatCli)           //aqui captura os dados do formulário
        {
            try
            {
                db.TbCliente.Add(oCatCli);                      //aqui adiciona no banco
                db.SaveChanges();                               // aqui salva no banco
                return RedirectToAction(nameof(Index));         // aqui retorna para pagina index.
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            TbCliente? oCatCli = db.TbCliente.Find(id);
            return View(oCatCli);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbCliente oCat)
        {
            var oCatCli = db.TbCliente.Find(id);
            oCatCli.CliNome = oCat.CliNome;
            oCatCli.CliDataNasc = oCat.CliDataNasc;
            oCatCli.CliCpf = oCat.CliCpf;
            oCatCli.CliEmail = oCat.CliEmail;            
            db.Entry(oCatCli).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            TbCliente? oCli = db.TbCliente.Find(id);
            db.Entry(oCli).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ClienteController/Delete/5
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
