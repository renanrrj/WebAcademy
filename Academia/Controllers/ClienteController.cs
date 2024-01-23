using Academia.Dados;
using Academia.Models;
using Academia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers
{
    public class ClienteController : Controller
    {
        readonly private ContextoBanco _db;
        public ClienteController(ContextoBanco db)
        {
            _db = db;
        }

        //------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult IndexCliente()
        {
            IEnumerable<ClienteModel> clientes = _db.Tb_Clientes;
            return View(clientes);
        }

        public IActionResult AdicionarCliente()
        {
            return View();
        }

        public IActionResult EditarCliente()
        {
            return View();
        }

        public IActionResult ExcluirCliente()
        {
            return View();
        }

        //------------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult AdicionarCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Tb_Clientes.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction("IndexCliente");
            }
            else { return View(); }
            
        }
    }
}
