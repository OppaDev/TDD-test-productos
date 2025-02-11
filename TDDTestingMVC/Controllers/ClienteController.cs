using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC.data;

namespace TDDTestingMVC.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.GetAllClientes().ToList();
            return View(clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                objClienteDAL.AddCliente(objCliente);
                return RedirectToAction("Index");

            }
            return View(objCliente);
        }
    }
}
