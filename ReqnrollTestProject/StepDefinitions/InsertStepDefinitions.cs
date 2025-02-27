using System;
using Reqnroll;
using TDDTestingMVC.data;
using TDDTestingMVC.Models;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDataAccessLayer = new ClienteDataAccessLayer();
        [Given("Completar la informacion en el formulario")]
        public void GivenCompletarLaInformacionEnElFormulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count();

            //Assert
            Assert.True(resultado > 0);

        }

        [When("Registro del Cliente en la BDD")]
        public void WhenRegistroDelClienteEnLaBDD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            Cliente cls = new Cliente();

            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Apellidos = item.Apellidos;
                cls.Nombres = item.Nombres;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
            }

            _clienteDataAccessLayer.AddCliente(cls);

        }

        [Then("El resultado del rgistro en la BDD")]
        public void ThenElResultadoDelRgistroEnLaBDD(DataTable dataTable)
        {
            var clientes = _clienteDataAccessLayer.GetAllClientes();
            var clienteRegistrado = dataTable.CreateSet<Cliente>().ToList();
            bool encontrado = false;

            foreach (var item in clienteRegistrado)
            {
                var cliente = clientes.Find(x => x.Cedula == item.Cedula);
                if (cliente != null)
                {
                    encontrado = true;
                }

            }

            Assert.True(encontrado);

        }
    }
}
