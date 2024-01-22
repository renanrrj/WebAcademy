using Academia.Models;
using Academia.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Controllers
{
    public class ClienteController : Controller
    {        
        
        public IActionResult IndexCliente()
        {
            return View();
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


        [HttpPost]
        public IActionResult AdicionarCliente(ClienteModel CliModel)
        {
            
            return RedirectToAction("IndexCliente");
        }





    }
}
