using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Text.RegularExpressions;

namespace TestCliente
{
    public class TestAutomation : IDisposable
    {
        private readonly IWebDriver driver;

        public TestAutomation()
        {
            driver = new FirefoxDriver();
        }

        [Fact]
        public void Datos_vacios()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("password")).SendKeys("");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);

            //Aseeert
            var email = driver.FindElement(By.Name("email"));
            var password = driver.FindElement(By.Name("password"));

            Assert.Equal("true", email.GetAttribute("required"));
            Assert.Equal("true", password.GetAttribute("required"));


        }
        public bool EsMailValido(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        [Theory] 
        [InlineData("correo_invalido.com", false)]

        public void ValidarEmail_DeberiaDetectarCorreoValido(string email, bool esperado)
        {
            bool resultado = EsMailValido(email);
            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Correo_invalido()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("correo_invalido.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("password")).SendKeys("leojeff145");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);

            //Aseeert
            var email = driver.FindElement(By.Name("email"));
            var password = driver.FindElement(By.Name("password"));

            Assert.Equal("true", email.GetAttribute("required"));
            Assert.Equal("true", password.GetAttribute("required"));

        }
        [Fact]
        public void Password_invalido()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("leonardojeffer.145@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("password")).SendKeys("leojeff123");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);

            //Aseeert
            Thread.Sleep(2000);
            var p = driver.FindElement(By.CssSelector("p[style='color: red;']"));            
            Assert.Equal("Your email or password is incorrect!", p.Text);
        }

        [Fact]
        public void Login_exitoso()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("leonardojeffer.145@gmail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("password")).SendKeys("leojeff145");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);

            //Aseeert
            Assert.Equal("https://www.automationexercise.com/login", driver.Url);
        }

        public void Dispose()
        {
            driver?.Dispose();
        }
    }


}
