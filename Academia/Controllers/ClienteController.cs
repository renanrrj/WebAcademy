using Academia.Dados;
using Academia.Models;
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

        [HttpGet]
        public IActionResult AdicionarCliente()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditarCliente(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Tb_Clientes.FirstOrDefault(c => c.Id == id);

            if(cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult ExcluirCliente(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ClienteModel cliente = _db.Tb_Clientes.FirstOrDefault(x => x.Id == id);

            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
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

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Tb_Clientes.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction("IndexCliente");
            }
            else { return View(cliente); }
        }

        [HttpPost]
        public IActionResult ExcluirCliente(ClienteModel cliente)
        {
            if (cliente == null)
            {
                return NotFound();
            }
            _db.Tb_Clientes.Remove(cliente);
            _db.SaveChanges();
            return RedirectToAction("IndexCliente");

        }
    }
}
