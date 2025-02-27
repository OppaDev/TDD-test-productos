using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC.data;
using TDDTestingMVC.Models;

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
        //Editar cliente
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente cliente)
        {
            if (id != cliente.Codigo)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                objClienteDAL.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        //Detalles del cliente
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        //Eliminar cliente
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objClienteDAL.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id, Cliente cliente)
        {
            objClienteDAL.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
