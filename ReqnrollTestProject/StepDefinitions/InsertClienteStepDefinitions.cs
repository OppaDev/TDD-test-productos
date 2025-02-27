using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject.Utilities;
using TDDTestingMVC.data;
using TDDTestingMVC.Models;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class InsertClienteStepDefinitions
    {
        private IWebDriver _driver;

        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;
        private readonly ClienteDataAccessLayer _clienteDataAccessLayer = new ClienteDataAccessLayer();

        public InsertClienteStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("Report/ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("firefox");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("El usuario se necuentra en la pagina Cliente")]
        public void GivenElUsuarioSeNecuentraEnLaPaginaCliente()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Index");
            _test?.Log(Status.Info, "El usuario esta en la pagina Cliente/Index");
        }

        [Given("El usuario da clic en el boton nuevo Cliente")]
        public void GivenElUsuarioDaClicEnElBotonNuevoCliente()
        {
            _driver.FindElement(By.Name("btnNuevoCliente")).Click();
            _test?.Log(Status.Info, "El usuario hizo clic en el boton nuevo Cliente");
        }

        [When("El usuario ingresa los siguientes datos")]
        public void WhenElUsuarioIngresaLosSiguientesDatos(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();
            Cliente cls = new Cliente();
            foreach (var item in cliente)
            {
                _driver.FindElement(By.Name("Cedula")).SendKeys(item.Cedula);
                _driver.FindElement(By.Name("Apellido")).SendKeys(item.Apellidos);
                _driver.FindElement(By.Name("Nombre")).SendKeys(item.Nombres);
                _driver.FindElement(By.Name("FechaNacimiento")).SendKeys(item.FechaNacimiento.ToString());
                _driver.FindElement(By.Name("Email")).SendKeys(item.Mail);
                _driver.FindElement(By.Name("Telefono")).SendKeys(item.Telefono);
                _driver.FindElement(By.Name("Direccion")).SendKeys(item.Direccion);
                _driver.FindElement(By.Name("Estado")).SendKeys(item.Estado);
            }
            _test?.Log(Status.Info, "El usuario ingreso los datos correctamente");

        }

        [When("Hacer clic en el boton crear")]
        public void WhenHacerClicEnElBotonCrear()
        {
            try
            {
                _driver.FindElement(By.CssSelector("button[data-qa='create-button']")).Click();
                bool isCreated = _driver.FindElement(By.CssSelector("button[data-qa='create-button']")) != null;
                _test?.Log(Status.Pass, "Usuario hizo clic corrctamente");
            }
            catch (NoSuchElementException)
            {
                _test?.Log(Status.Fail, "Error al hacer clic en el boton de inicio de sesion");
            }
        }

        [Then("el usuario se queda en la pagina agregar cliente")]
        public void ThenElUsuarioSeQuedaEnLaPaginaAgregarCliente()
        {
            try
            {
                bool isCreated = _driver.FindElement(By.CssSelector("button[data-qa='create-button']")) != null;
                _test?.Log(Status.Pass, "Usuario se quedo en la pagina de agregar cliente");
            }
            catch (NoSuchElementException)
            {
                _test?.Log(Status.Fail, "Usuario no se quedo en la pagina de agregar cliente");
            }
        }
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
