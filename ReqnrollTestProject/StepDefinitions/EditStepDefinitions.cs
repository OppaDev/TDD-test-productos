using System;
using Reqnroll;
using TDDTestingMVC.data;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class EditStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDataAccessLayer = new ClienteDataAccessLayer();
        
        [Given("Mostrar la informacion a editar en el formulario")]
        public void GivenMostrarLaInformacionAEditarEnElFormulario(DataTable dataTable)
        {
            

        }

        [When("Edicion de los datos del cliente en la BDD")]
        public void WhenEdicionDeLosDatosDelClienteEnLaBDD(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [Then("Resultado de la edicion en la BDD")]
        public void ThenResultadoDeLaEdicionEnLaBDD(DataTable dataTable)
        {
            throw new PendingStepException();
        }
    }
}
