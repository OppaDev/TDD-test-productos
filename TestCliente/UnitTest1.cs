using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace TestCliente
{
    public class UnitTest1
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        
        public UnitTest1()
        {
            var options = new FirefoxOptions();
            options.SetPreference("dom.webdriver.enable", false);
            options.SetPreference("useAutomationExtension", false);

            _driver = new FirefoxDriver(@"C:\GeckoDriver\geckodriver.exe", options);

            _driver.Manage().Window.Maximize(); 

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
        }


        public bool EsMailValido(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        [Theory]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("test@empresa.com", true)]
        [InlineData("correo_invalido.com", false)]
        [InlineData("SinFormatoCorreo", false)]
        public void ValidarEmail_DeberiaDetectarCorreoValido(string email, bool esperado)
        {
            bool resultado = EsMailValido(email);
            //Assert
            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void Test_NavegadorGoogle()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.google.com");
                //Buscar dentro del navegador informacion
                var buscarTexto = _driver.FindElement(By.Name("q"));
                Thread.Sleep(2000);
                buscarTexto.SendKeys("Selenium");
                
                buscarTexto.SendKeys(Keys.Enter);

                var resultado = _wait.Until(d => d.FindElements(By.CssSelector("h2")));

                Assert.True(resultado.Count > 0, "No se encontraron resultados de la busqueda");

                Thread.Sleep(20000);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _driver.Quit();

                _driver.Dispose();
            }
        }
    }
}
