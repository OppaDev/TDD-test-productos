using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject.Utilities;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
        private IWebDriver _driver;

        private static ExtentReports _extent;
        private ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LogInStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }
        [BeforeScenario]
        public void BeforeScenario() {
            _driver = WebDriverManager.GetDriver("firefox");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }


        [Given("que el usuario esta en la pagina del login")]
        public void GivenQueElUsuarioEstaEnLaPaginaDelLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Info, "El usuario esta en la pagina del login");
        }

        [When("ingresa un correo {string} y la contraseña {string}")]
        public void WhenIngresaUnCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario Ingresa correo: {email} y contraseña: {password}");
        }

        [When("hacer clic en el boton de inicio de sesión")]
        public void WhenHacerClicEnElBotonDeInicioDeSesion()
        {
            try
            {
                _driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();
                bool isLoggedIn = _driver.FindElement(By.CssSelector("button[data-qa='login-button']")) != null;
                _test.Log(Status.Pass, "Usuario hizo clic corrctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "Error al hacer clic en el boton de inicio de sesion");
            }
        }

        [Then("deveria ver un mensaje de error")]
        public void ThenDeveriaVerUnMensajeDeError()
        {
            try
            {
                
                bool isError = _driver.FindElement(By.CssSelector("p[style='color: red;']")).Text != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado correctamente");

            }

            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostro el mensaje error");
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
